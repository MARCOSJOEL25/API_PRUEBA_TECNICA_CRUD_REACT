import React from "react";

const DataShowed = ({ data, IsModalOn, setIsModalOn, setUpdate, DeleteDataitem}) => {

    const sendDataUpdate = (contacto) => {
        console.log(contacto.nombre)
        setUpdate(contacto)
        setIsModalOn(!IsModalOn)
    }

    return (
        <table className="table table-striped table-bordered">
            <thead className="thead-dark">
                <tr>
                    <th>Nombre</th>
                    <th>Correos</th>
                    <th>Telefonos</th>
                    <th>Opciones</th>
                </tr>
            </thead>
            <tbody>
                {data.map((item) => (
                    <tr key={ item.idContacto}>
                        <td>{item.nombre}</td>
                        <td>{item.correo}</td>
                        <td>{item.telefono}</td>
                        <td>
                            <button className="btn btn-warning"
                                onClick={() => sendDataUpdate(item) }
                            >Edit</button>
                            <button className="btn btn-danger" onClick={() => DeleteDataitem(item.idContacto)}>Delete</button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
        )
}

export default DataShowed;