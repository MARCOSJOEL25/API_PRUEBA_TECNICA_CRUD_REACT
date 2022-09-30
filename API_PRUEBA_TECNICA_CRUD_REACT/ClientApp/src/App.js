import React, { useEffect, useState } from 'react';
import DataShowed from './components/DataShowed';
import { FetchData } from './components/FetchData';

import './custom.css'

const App = () => {
    const [contacto, setContacto] = useState([]);

    const fetchDataAll = async () => {
        const response = await FetchData();
        setContacto(response)
    }

    useEffect(() => { fetchDataAll() }, [])
    console.log(contacto)

//<div className=""></div>
    return (
        <div className="container m-5">
            <div className="row">
                <div className="col-sm-12">
                    <div className="Card">
                        <div className="header-card">
                            <h4>Data Contacts</h4>
                            <hr></hr>
                        </div>
                        <div className="body-card">
                            <button className="btn btn-success">Nuevo Contacto</button>
                            <hr></hr>
                            <DataShowed data={contacto}/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  )
}

export default App;
