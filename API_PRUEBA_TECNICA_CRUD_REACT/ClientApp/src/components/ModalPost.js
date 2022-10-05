import React, { useState, useEffect } from 'react';
import { Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";

const ModalPost = ({ IsModalOn, setIsModalOn, saveData, Update, setUpdate, updateDataitem}) => {

    const modelContact = {
        idContacto : 0,
        nombre: "",
        correo: "",
        telefono: ""
    }

    const [contacto, setContacto] = useState(modelContact)

    const updateData = (e) => {
        console.log(e.target.name + " : " + e.target.value)
        setContacto(
            {
                ...contacto,
                [e.target.name]: e.target.value
            }
        )
    }

    const PostData = () => {
        if (contacto.idContacto == 0) {
            saveData(contacto)
        } else {
            updateDataitem(contacto)
        }
        setContacto(modelContact)
    }

    useEffect(() => {
        if (Update != null) {
            setContacto(Update)
        } else {
            setContacto(modelContact)
        }
    }, [Update])

    const closeModal = () => {
        setIsModalOn(!IsModalOn)
        setUpdate(null)
    }
    return (
        <Modal isOpen={IsModalOn}>
            <ModalHeader>
                { contacto.idContacto == 0 ? "Nuevo contacto" : "Editar Contacto"} 
            </ModalHeader>
            <ModalBody>
                <form>
                    <div className="form-group">
                         <label>Nombre</label>
                         <input
                            type="text"
                            name="nombre"
                            onChange={(e) => updateData(e)}
                            value={contacto.nombre}
                    />
                    </div>
                    <div className="form-group">
                        <label>Correo</label>
                         <input
                            type="text"
                            name="correo"
                            onChange={(e) => updateData(e)}
                            value={contacto.correo}

                    />
                    </div>
                    <div className="form-group">
                        <label>Telefono</label>
                        <input
                            type="text"
                            name="telefono"
                            onChange={(e) => updateData(e)}
                            value={contacto.telefono}

                    />
                    </div>
                </form>
            </ModalBody>
            <ModalFooter>
                <button className="btn btn-primary" onClick={ PostData }>
                    Insertar
                </button>
                {"  "}
                <button className="btn btn-danger" onClick={closeModal}>
                    Cancelar
                </button>
            </ModalFooter>
        </Modal>

    )
}

export default ModalPost;