import React, { Component } from 'react'
import './Admin.css'

import Navbar from '../../Components/Navbar-consultas/Navbar'

class Admin extends Component {
    constructor() {
        super();
        this.state = {
            nome: '',
            rg: '',
            cpf: '',
            datanascimento: '',
            email: '',
            senha: '',
            idcredencial: ''
        }
    }

    cadastrar(e) {
        e.preventDefault()      

        
        fetch('http://192.168.3.48:5000/api/Usuarios/cadastro',
            {
                method: 'POST',
                body: JSON.stringify({
                    email : this.state.email,
                    senha : this.state.senha,
                    permicao : this.state.idcredencial
                }),
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("usuario")
                }
            })

            .then(data => console.log(data))
            .catch(erro => console.log(erro))

        this.props.history.push('/admin/consulta')
    }

    atualizarNome(e) {
        this.setState({ nome: e.target.value })
        console.log(this.state)
    }

    atualizarRg(e) {
        this.setState({ rg: e.target.value })
    }

    atualizarCpf(e) {
        this.setState({ cpf: e.target.value })
    }

    atualizarDataNascimento(e) {
        this.setState({ datanascimento: e.target.value })
    }

    atualizarTelefone(e) {
        this.setState({ telefone: e.target.value })
    }

    atualizarLogradouro(e) {
        this.setState({ logradouro: e.target.value })
    }

    atualizarNumero(e) {
        this.setState({ numero: e.target.value })
    }

    atualizarBairro(e) {
        this.setState({ bairro: e.target.value })
    }

    atualizarCidade(e) {
        this.setState({ cidade: e.target.value })
    }

    atualizarEstado(e) {
        this.setState({ estado: e.target.value })
    }

    atualizarEmail(e) {
        this.setState({ email: e.target.value })
    }

    atualizarSenha(e) {
        this.setState({ senha: e.target.value })
    }

    atualizarConfirmarSenha(e) {
        this.setState({ confirmarsenha: e.target.value })
    }

    atualizarCredencial(e) {
        this.setState({ idcredencial: e.target.value })
    }



    render() {
        return (
            <div className="fundo-admin">
                <Navbar />
                <div className="container-adm">
                    <h1>Cadastrar Usuário</h1>
                    <div className="card card-admin cadastrar-usuario">


                        <form className="formulario" method="" onSubmit={this.cadastrar.bind(this)}>
                            <div className="informacoes-pessoais col-5">
                                <h2>Informações do usuário</h2>
                                <input name="nome"
                                    className="input-cadastro"
                                    type="text"
                                    placeholder="Nome Completo"
                                    onChange={this.atualizarNome.bind(this)}
                                />
                                <input name="rg"
                                    className="input-cadastro"
                                    type="text"
                                    placeholder="RG"
                                    onChange={this.atualizarRg.bind(this)}
                                />
                                <input name="cpf"
                                    className="input-cadastro"
                                    type="text"
                                    placeholder="CPF"
                                    onChange={this.atualizarCpf.bind(this)}
                                />
                                <input name="datanascimento"
                                    className="input-cadastro"
                                    type="date"
                                    placeholder="Data de nascimento"
                                    onChange={this.atualizarDataNascimento.bind(this)}
                                />
                                <input name="telefone"
                                    className="input-cadastro"
                                    type="text"
                                    placeholder="Telefone"
                                    data-mask="(00) 00000-0000"
                                    onChange={this.atualizarTelefone.bind(this)}
                                />
                            </div>
                            <div className="informacoes-login col-6">

                                <input name="email"
                                    className="input-cadastro"
                                    type="text"
                                    placeholder="Email"
                                    onChange={this.atualizarEmail.bind(this)}
                                />
                                <input name="senha"
                                    className="input-cadastro"
                                    type="password"
                                    placeholder="Senha"
                                    onChange={this.atualizarSenha.bind(this)}
                                />
                                <input name="confirmarsenha"
                                    className="input-cadastro"
                                    type="password"
                                    placeholder="Confirmar senha"
                                    onChange={this.atualizarConfirmarSenha.bind(this)}
                                />
                                <select className="select-credencial" name="" id="selecionar-credencial" onChange={this.atualizarCredencial.bind(this)}>
                                    <option value="" defaultValue="selected">Selecione</option>
                                    <option value="administrador">Administrador</option>
                                    <option value="medico">Medico</option>
                                    <option value="paciente">Paciente</option>
                                </select>
                                <br />

                            </div>
                            <button type="submit" className="botao-cadastrar">Cadastrar</button>

                        </form>

                    </div>
                </div>
            </div>
        )
    }
}

export default Admin