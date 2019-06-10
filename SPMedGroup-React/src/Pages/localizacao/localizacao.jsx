import Navbar from '../../Components/Navbar-consultas/Navbar.jsx'
import React, { Component } from 'react'
import './localizacao.css';


class localizacao extends Component {

    render() {

        return (


            <div >
                <Navbar />
                <div className="back">
                    <div className="card">

                        <iframe title="gmap" id="gmap_canvas" src="https://maps.google.com/maps?q=s%C3%A3o%20paulo&t=&z=11&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0">
                        </iframe>



                    </div>

                </div>




            </div>)
    }
}

export default localizacao;