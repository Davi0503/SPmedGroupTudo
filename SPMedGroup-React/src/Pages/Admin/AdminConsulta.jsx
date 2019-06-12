import React, { Component } from 'react'

import Navbar from '../../Components/Navbar-consultas/Navbar'

//refazer request de consultas 

class AdminConsulta extends Component {
    constructor() {
        super();
        this.state = {
            listaMedicos: [],
            listaPacientes: []
        }

        this.consulta = {
            horaConsulta: '',
            dataConsulta: '',
            idPaciente: '',
            idMedico: '',
            statusConsulta: 1,
        }

    }

    componentDidMount() {
        fetch('http://192.168.3.48:5000/api/Usuarios/Medicos',
            {
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("usuario")
                }
            })
            .then(response => response.json())
            .then(data => this.setState({ listaMedicos: data }))
            .catch(erro => console.log(erro))

        fetch('http://192.168.3.48:5000/api/Usuarios/Pacientes',
            {
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("usuario")
                }
            })
            .then(response => response.json())
            .then(data => this.setState({ listaPacientes: data }))
            .catch(erro => console.log(erro))

    }

    atualizarData(e) {
        this.consulta.dataConsulta = e.target.value + 'T00:00:00'
        console.log(this.consulta)
    }

    atualizarHora(e) {
        this.consulta.horaConsulta = e.target.value + ':00'
        console.log(this.consulta)
    }

    atualizarMedico(e) {
        this.consulta.idMedico = e.target.value
        console.log(this.consulta)
    }

    atualizaRPaciente(e) {
        this.consulta.idPaciente = e.target.value
        console.log(this.consulta)
    }

   

    

    cadastrar(e) {
        
        
        fetch('http://192.168.3.48:5000/api/Consultas/inserir',
            {
                method: 'POST',
                body: JSON.stringify(this.consulta),
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("usuario")
                }
            })
            .then(data => function(){
            window.location.reload();
            })
            .catch(erro => console.log(erro))
    }

    render() {
        return (
            <div className="fundo-admin">
                <Navbar />
                <div className="card card-admin cadastrar-usuario">
                    <form className="form-cons" method="" onSubmit={this.cadastrar.bind(this)}>
                        <h1>Cadastrar Consulta</h1>
                        <h2>Informações</h2>
                        <input name="datanascimento"
                            className="input-cadastro"
                            type="date"
                            placeholder="Data de nascimento"
                            onChange={this.atualizarData.bind(this)}
                        />
                        <br />
                        <select className="select-credencial" name="" onChange={this.atualizarMedico.bind(this)} id="selecionar-credencial">
                            <option value="" defaultValue="selected">Selecione</option>
                            {this.state.listaMedicos.map(chave => {
                                return <option value={chave.id} key={chave.id}>{chave.nome}</option>
                            })}
                        </select>
                        <br />
                        <select className="select-credencial" name="" onChange={this.atualizaRPaciente.bind(this)} id="selecionar-credencial">
                            <option value="" defaultValue="selected">Selecione</option>
                            {this.state.listaPacientes.map(chave => {
                                return <option value={chave.id} key={chave.id}>{chave.nome}</option>
                            })}
                        </select>
                        <br />
                        <button type="submit" onChange={this.cadastrar.bind(this)} className="botao-cadastrar">Cadastrar</button>
                    </form>
                </div>
            </div>
        )
    }
}

export default AdminConsulta