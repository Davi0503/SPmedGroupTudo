import React, { Component } from 'react'
import './Navbar.css'
import sair from '../../Img/baseline_exit_to_app_black_18dp.png';

class Navbar extends Component {
    render() {
        return (
            <div className="nav">
                <div className="col-10">

                    

                </div>
                

                <div className="btnzin col-2">
                    
                    <a className="btn" href="http://localhost:3000/login" onClick={() => localStorage.removeItem("usuario")}>
                    <img className="icon" src={sair}/>                    
                    </a>
                    

                </div>

            </div>
        )
    }
}

export default Navbar