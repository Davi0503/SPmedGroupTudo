import React from 'react'
import './Card.css'

import Info from './Info'

export default props => {
    return (
        <div className="card">
            <div className="doutor-info">
                <div className="batatinha">
                <Info titulo="Data" info={props.data} />
                <Info titulo="Especialidade" info={props.especialidade} />
                <Info titulo="Médico" info={props.medico} />
                </div>
               
            </div>

            <div className="data-hora">                      
                <Info titulo="Hora" info={props.hora} />
                <Info titulo="Status" info={props.status} />
            </div>
            
        </div>
    )
}