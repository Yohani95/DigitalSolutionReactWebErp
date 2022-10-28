import { Table } from "reactstrap";
const TableComp = ({ data }) => {
    return (
    <Table striped responsive className="text-center">
        <thead>
            <tr>
                <th>Nombre</th>
                <th>Apellido</th>
                <th>Rut</th>
                <th>Cargo</th>
                <th>Nombre de Usuario</th>
                <th className="text-center">Acciones</th>
            </tr>
        </thead>
        <tbody>
            {
                (data.map(item => (
                    <tr key={item.id_usuario}>
                        <td>{item.nombre}</td>
                        <td>{item.apellido}</td>
                        <td>{item.rut}</td>
                        <td>{item.roles.nombre_rol}</td>
                        <td>{item.nombre_usuario}</td>
                        <td className="text-center">
                            <button className="btn btn-primary me-2">Editar</button>
                            <button className="btn btn-danger me-2">Eliminar</button>
                            <button className="btn btn-warning">Ver</button>
                        </td>

                    </tr>
                )))
            }
        </tbody>

    </Table >
        )
}
export default TableComp