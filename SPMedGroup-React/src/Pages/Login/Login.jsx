import React, { Component } from 'react'
import Axios from 'axios'
import { parseJwt } from '../../Services/Auth'

import './Login.css'
import Logo from '../../Img/logo-spmed.png'
import background from '../../Img/background.jpg'

class Login extends Component {
    constructor() {
        super();
        this.state = {
            email: '',
            senha: '',
            mensagemErro: '',
        }
    }

    atualizarEstadoEmail(e) {
        this.setState({ email: e.target.value })
    }

    atualizarEstadoSenha(e) {
        this.setState({ senha: e.target.value })
    }

    efetuarLogin(e) {


        e.preventDefault()

        
        Axios.post("http://192.168.3.48:5000/api/Login", {
            email: this.state.email,
            senha: this.state.senha
        })
            .then(data => {
                if (data.status === 200) {
                    console.log(data);
                    localStorage.setItem("usuario", data.data.token);
                    var credencial = Object.values(parseJwt())[2]

                    
                    debugger
                    if (credencial === "paciente" || credencial === "medico" || credencial == "1") {
                        this.props.history.push('/consultas');
                    } else {
                        this.props.history.push("/admin/usuario")
                    }
                }

                console.log(data)
            })
            .catch(erro => {
                this.setState({ erroMensagem: 'Email ou senha inválidos' });
            })
    }


    render() {
        return (
            <div className="login-background">
                <div className="filter">

                    <div className="login-box">
                        <form onSubmit={this.efetuarLogin.bind(this)} className="login-form">
                            <img src={Logo} className="imagem" alt="" width="50%" />
                            <input name="email"
                                className="input-padrao"
                                type="text"
                                placeholder="Email"
                                value={this.state.email}
                                onChange={this.atualizarEstadoEmail.bind(this)} />
                            <input name="senha"
                                className="input-padrao"
                                placeholder="Senha"
                                type="password"
                                value={this.state.senha}
                                onChange={this.atualizarEstadoSenha.bind(this)} />
                            <p className="text__login" style={{ color: 'red' }}>{this.state.erroMensagem}</p>
                            <button type="submit" className="login-button">Fazer Login</button>
                        </form>
                    </div>
                </div>
            </div>
        )
    }
}

export default Login