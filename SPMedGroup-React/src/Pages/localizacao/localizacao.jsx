import Navbar from '../../Components/Navbar-consultas/Navbar.jsx'
import React, { Component } from 'react'


class localizacao extends Component {

    render() {

        return (


            <div >
                <Navbar />
                <div className="back">
                    <div className="card">

                        <input name="latitude"
                            className="input-cadastro"
                            type="text"
                            placeholder="Latitude"
                        />

                        <input name="latitude"
                            className="input-cadastro"
                            type="text"
                            placeholder="longitude"
                        />

                    </div>

                </div>




            </div>)
    }
}

export default localizacao;