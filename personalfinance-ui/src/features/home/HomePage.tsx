import { Link } from "react-router-dom";
import { Container } from "semantic-ui-react";

export default function HomePage() {
  return(
<Container style={{marginTop: '7em'}}>
    <h1>Home Page</h1>
    <h3>go to <Link to= '/activities'>Activities</Link></h3>
    <h3>go to <Link to= '/revenues'>Revenues</Link></h3>

</Container>

  )
}
