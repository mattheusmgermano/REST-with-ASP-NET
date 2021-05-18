import React, { useEffect, useState } from 'react';
import {Link, useHistory, useParams } from 'react-router-dom';
import api from '../../services/api'

import {FiArrowLeft} from 'react-icons/fi'
import './styles.css';
import logoImage from '../../assets/mybookself.svg';

export default function NewBook(){

    const [id, setId] = useState(null);
    const [author, setAuthor] = useState('');
    const [title, setTitle] = useState('');
    const [launchDate, setLaunchDate] = useState('');
    const [price, setPrice] = useState('');

    const { bookId } = useParams();

    const history = useHistory();

    const accessToken = localStorage.getItem('accessToken');

    const authorization = {
        headers: {
            Authorization: `Bearer ${accessToken}`
        }
    }

    useEffect(() => {
        if(bookId === '0') return;
        else loadBook();
    }, bookId);

    async function loadBook() {
        try {
            const response = await api.get(`api/books/v1/${bookId}`, authorization)

            let adjustedDate = response.data.launchDate.split("T", 10)[0];

            setId(response.data.id);
            setTitle(response.data.title);
            setAuthor(response.data.author);
            setPrice(response.data.price);
            setLaunchDate(adjustedDate);
        } catch (error) {            
            alert('Macacos me mordam, ocorreu um erro! Tente novamente em instantes!')
            history.push('/books');
        }
    }

    async function saveOrUpdate(e) {
        e.preventDefault();

        const data = {
            title,
            author,
            launchDate,
            price,
        }

        try {
            if(bookId === '0') {
                await api.post('api/Books/v1', data, authorization);
            } else {
                data.id = id;
                await api.put('api/Books/v1', data, authorization);
            }
        } catch (err) {
            alert('Pelas barbas do profeta! Aconteceu algo enquanto tentavamos cadastrar!')
        }
        history.push('/books');
    }

    return (
        <div className="new-book-container">
            <div className="content">
                <section className="form">
                    <img src={logoImage} alt="MyBookSelf logo"/>
                    <h1>{bookId === '0'? 'Adicionar' : 'Atualizar'} Livro</h1>
                    <p>Preencha os campos para  <strong>{bookId === '0' ? `adicionar` : `atualizar`}</strong>!</p>
                    <Link className="back-link" to="/books">
                        <FiArrowLeft size={16} color="#251fc5"/>
                        Início
                    </Link>
                </section>

                <form onSubmit={saveOrUpdate}>
                    <input 
                        placeholder="Título"
                        value={title}
                        onChange={e => setTitle(e.target.value)}
                        required
                    />
                    <input 
                        placeholder="Autor"
                        
                        value={author}
                        onChange={e => setAuthor(e.target.value)}
                        required
                    />
                    <input 
                        type="date"
                        
                        value={launchDate}
                        onChange={e => setLaunchDate(e.target.value)}
                    />
                    <input 
                        placeholder="Preço"
                        
                        value={price}
                        onChange={e => setPrice(e.target.value)}
                        required
                    />

                    <button className="button" type="submit">{bookId === '0'? 'Add' : 'Update'}</button>
                </form>
            </div>
        </div>
    );
}