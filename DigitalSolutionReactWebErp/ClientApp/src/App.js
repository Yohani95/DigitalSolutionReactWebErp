import { Col, Container, Row, CardHeader, CardBody, Button } from "reactstrap";
import axios, { AxiosResponse } from 'axios';
import { useState, useEffect} from "react";
import { urlErp } from './endpoint';
import TableComp from './componentes/Html/TableComp';
const App = () => {
    const [user, setUser] = useState([])
    const url = "/api/User/Lista";
    const peticion = async () => {
        await axios.get(urlErp+url).then((response: AxiosResponse<any>) => {
            setUser(response.data);
       }).catch(error => {console.log("Error en la solicitud api")})
    }
    useEffect(() => {
     peticion()
    }, [])
    return (
        <Container>
            <Row class="mt-5">
                <Col sm="12">
                    <CardHeader>
                        <h2>Lista Usuarios</h2>
                    </CardHeader>
                    <CardBody>
                        <Button className="btn btn-success">Agregar Usuario</Button>
                        <TableComp data={user}/>
                    </CardBody>
                    <hr></hr>
                </Col>
            </Row>
        </Container>
        )
}
export default App;

