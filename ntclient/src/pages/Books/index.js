import React, { useState, useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';
import {FiLogOut, FiEdit, FiTrash2} from 'react-icons/fi'

import api from '../../services/api';

import './styles.css';
import logoImage from '../../assets/mybookself.svg';

export default function Book(){
    const [books, setBooks] = useState([]);
    const [page, setPage] = useState(1);

    const userName = localStorage.getItem('userName');
    const accessToken = localStorage.getItem('accessToken');

    const authorization = {
        headers: {
            Authorization: `Bearer ${accessToken}`
        }
    }

    const history = useHistory();

    useEffect(() => {
        fetchMoreBooks();
    }, [accessToken]);

    async function fetchMoreBooks() {
        const response = await api.get(`api/books/v1/asc/4/${page}`, authorization);
        setBooks([ ...books, ...response.data.list]);
        setPage(page + 1);
    }
    
    async function sair() {
        try {
            await api.get('api/auth/v1/revoke', authorization);

            localStorage.clear();
            history.push('/');
        } catch (err) {
            alert('Logout falhou. Tente novamente.');
        }
    }
    
    async function editBook(id) {
        try {
            history.push(`books/novo/${id}`)
        } catch (err) {
            alert('Ocorreu um erro! Tente novamente.');
        }
    }

    async function deleteBook(id) {
        try {
            await api.delete(`api/Books/v1/${id}`, authorization);

            setBooks(books.filter(book => book.id !== id))
        } catch (err) {
            alert('Oh não, ocorreu um erro! Tente novamente.');
        }
    }

    return(
        <div className="book-container">
            <header>
                <img className="logo" src={logoImage} alt="MyBookSelf logo"/>
                <span>Olá, <strong>{userName.toLowerCase()}</strong></span>
                <Link className="button" to="books/novo/0">Adicionar Livro</Link>
                <button onClick={sair} type="button">
                    <FiLogOut size={18} color="#251fc5"/>
                </button>
            </header>
            <h1>Livros registrados</h1>
            <ul>
                {books.map(book => (
                    <li key={book.id}>
                        <strong>Título:</strong>
                        <p>{book.title}</p>
                        <strong>Autor:</strong>
                        <p>{book.author}</p>
                        <strong>Preço:</strong>
                        <p>{Intl.NumberFormat('pt-BR', {style: 'currency', currency: 'BRL'}).format(book.price)}</p>
                        <strong>Data de Lançamento:</strong>
                        <p>{Intl.DateTimeFormat('pt-BR').format(new Date(book.launchDate))}</p>
                        
                        <button onClick={() => editBook(book.id)} type="button">
                            <FiEdit size={20} color="#251FC5"/>
                        </button>
                        
                        <button onClick={() => deleteBook(book.id)} type="button">
                            <FiTrash2 size={20} color="#251FC5"/>
                        </button>
                    </li>
                ))}
            </ul>
            <button className="button" onClick={fetchMoreBooks} type="button">Ver mais</button>
        </div>
    )
}