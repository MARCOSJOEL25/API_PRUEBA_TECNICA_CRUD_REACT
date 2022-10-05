import React, { useEffect, useState } from 'react';
import DataShowed from './components/DataShowed';
import { FetchData } from './components/FetchData';
import ModalPost from './components/ModalPost';

import './custom.css'

const App = () => {
    const [contactoData, setContactoData] = useState([]);
    const [IsModalOn, setIsModalOn] = useState(false);
    const [Update, setUpdate] = useState(null);

    const fetchDataAll = async () => {
        const response = await FetchData();
        setContactoData(response)
    }

    useEffect(() => { fetchDataAll() }, [])

    const saveData = async (contacto) => {
        const response = await fetch("api/contactos/SaveData", {
            method: 'POST',
            headers: {
                'content-type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(contacto)
        })

        if (response.ok) {
            setIsModalOn(!IsModalOn)
            fetchDataAll()
        }
    }

    const updateDataitem = async (contacto) => {
        const response = await fetch("api/contactos/Update", {
            method: 'PUT',
            headers: {
                'content-type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(contacto)
        })

        if (response.ok) {
            setIsModalOn(!IsModalOn)
            fetchDataAll()
        }
    }

    const DeleteDataitem = async (id) => {
        var res = window.confirm("Esta seguro que quiere eliminar el contacto")

        if (!res) {
            return;
        }

        const response = await fetch("api/contactos/Delete/" + id, {
            method: 'DELETE',
        })

        if (response.ok) {
            fetchDataAll()
        }
    }

    
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
                            <button className="btn btn-success" onClick={ ()=> setIsModalOn(!IsModalOn)} >Nuevo Contacto</button>
                            <hr></hr>
                            <DataShowed
                                data={contactoData}
                                IsModalOn={IsModalOn}
                                setIsModalOn={setIsModalOn}

                                setUpdate={setUpdate}
                                Update={Update}

                                DeleteDataitem={DeleteDataitem}

                            />
                            <ModalPost
                                IsModalOn={IsModalOn}
                                setIsModalOn={setIsModalOn}
                                saveData={saveData}

                                Update={Update}
                                setUpdate={setUpdate}
                                updateDataitem={updateDataitem}
                            />

                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
  )
}

export default App;
