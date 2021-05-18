import React, {useState} from 'react';
import {useHistory} from 'react-router-dom';
import api from '../../services/api'

import './styles.css';
import logoImage from '../../assets/mybookself.svg';
import padlock from '../../assets/padlock.png';
import library from '../../assets/library.jpg';

export default function Login()
{
    const[userName, setUserName] = useState('');
    const[password, setPassword] = useState('');

    const history = useHistory();

    async function login(e){
        e.preventDefault();

        const data = {
            userName,
            password,
        };
        try {
            const response = await api.post('api/auth/v1/signin', data);
            localStorage.setItem('userName', userName);
            localStorage.setItem('accessToken', response.data.accessToken);
            localStorage.setItem('refreshToken', response.data.refreshToken);
            
            history.push('/books')
        } catch (error) {
            alert('Login falhou. Tente novamente.');
        }
    }

    return (
        <div className="box-login">
            <div className="login-container">
            <section className="form">
            <img src={logoImage} alt="MyBookSelf logo"/>
            <form onSubmit={login}>
                <h1>Acesse sua conta:</h1>
                <input placeholder="Nome de usuário" 
                value ={userName}
                onChange={ e=> setUserName(e.target.value)}/>
                <input type="password" placeholder="Senha"
                value ={password}
                onChange={ e=> setPassword(e.target.value)}/>

                <button className ="button" type="submit">Entrar</button>
            </form>

            </section>
            <img className="cadeado" src={padlock} alt="Imagem de um cadeado."/>
            </div>
            <img className="library" src={library} alt="Imagem de uma mulher com um livro entre um frame de livros."/>
        </div>
    )
} 