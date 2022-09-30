import React from "react";

const DataShowed = ({ data }) => {
    return (
        <table className="table table-striped table-bordered">
            <thead className="thead-dark">
                <tr>
                    <th>Nombre</th>
                    <th>Correos</th>
                    <th>Telefonos</th>
                </tr>
            </thead>
            <tbody>
                {data.map((data) => (
                    <tr>
                        <td>{data.nombre}</td>
                        <td>{data.correo}</td>
                        <td>{data.telefono}</td>
                    </tr>
                ))}
            </tbody>
        </table>
        )
}

export default DataShowed;