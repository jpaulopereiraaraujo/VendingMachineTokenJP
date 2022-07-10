import videoBG from '../assets/block.mp4'
import Nav from "../components/Nav"

function Home() {
    return(
        <>
        
      <div className='mainVB'>
        <div className="overlay"></div>

        <video src={videoBG} autoPlay loop muted />
    </div>
    <Nav/>
        
        <div>

        <h1>Sobre mim</h1>
        <p>Pequena descrição</p>


        </div>

        
        </>
    
        )
   
}

export default Home;