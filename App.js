import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Home from './pages/Home'
import Faucet from './pages/Faucet'
import VendingMachine from "./pages/VendingMachine";
function App() {
    return(

        

        <Router>
            
            <Routes>
                <Route exact path="/" element={<Home />} > </Route>
                
                <Route path="/faucet" element={<Faucet />} > </Route>
                
                <Route path="/vendingmachine" element={<VendingMachine />} > </Route>


            </Routes>


            

        </Router>

    
    
    )
}

export default App
