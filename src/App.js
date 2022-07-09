import { useEffect, useState, useCallback } from "react";
import "./App.css"
import Web3 from "web3";
import detectEthereumProvider from '@metamask/detect-provider'
import {loadContract} from "./utils/load-contract";
import videoBG from './assets/block.mp4'



function App() {
  const [web3Api, setWeb3Api] = useState ({
    provider:null,
    web3:null,
    contract:null 
  })
  
  const[balance, setBalance]  = useState(null)
  const[balanceT, setBalanceT] = useState(null)
  const[account, setAccount] = useState(null)
  const [shouldReload, reload] = useState(false)

  const reloadEffect = useCallback(() => reload(!shouldReload), [shouldReload])

  const setAccountListener =provider => {
    provider.on("accountsChanged", accounts => setAccount(accounts[0]))
  }

  useEffect(() => {
      
    const loadProvider = async () => {
        //O primeiro if é para sistemas atualizados
        const provider = await detectEthereumProvider();
        const contract = await loadContract("JPToken", provider);
        
        if(provider){
          setAccountListener(provider)
          setWeb3Api({
            web3: new Web3(provider),
            provider,
            contract
          })

        } else {
          console.logerror("Please, install metamask.")
        }

      }
        

      loadProvider()
    }, [])

  
    useEffect (() => {
      const getAccount = async () => {
        
        const accounts = await web3Api.web3.eth.getAccounts()
        setAccount(accounts[0])
      }

      web3Api.web3 && getAccount()

    }, [web3Api.web3])

    useEffect(() => {

        const loadBalance = async () => {
        const { contract, web3 } = web3Api
        //getBalance é uma função nativa da lib
        const balance = await web3.eth.getBalance(contract.address)
        // converte de wei para ether
        setBalance(web3.utils.fromWei(balance,"ether"))

      }


      web3Api.contract && loadBalance()
    },[web3Api, shouldReload])

    useEffect(() => {
      
        
      

      const loadBalanceT = async () => {
      const { contract } = web3Api
      //getBalance é uma função nativa da lib
      const accounts = await web3Api.web3.eth.getAccounts()
      const balanceT = await contract.balanceOf(accounts[0]).then(b => {return b.toString()})
      // converte de wei para ether
      setBalanceT(balanceT)

    }


    web3Api.contract && loadBalanceT()
  },[web3Api, shouldReload])
    
    const buyToken10 = useCallback(async () => {
      const { contract, web3 } = web3Api
      await contract.buy10({
        from: account,
        value: web3.utils.toWei("1", "ether")
      })

      // 
      reloadEffect()
    }, [web3Api,account, reloadEffect])

    const sell10 = async () => {
      const { contract} = web3Api
      await contract.sell10({
        from: account
         
      })
      reloadEffect()

    }

  
  return (

    
    <>

      <div className='mainVB'>
        <div className="overlay"></div>

        <video src={videoBG} autoPlay loop muted />

      </div>


<nav class="navbar is-transparent">
  <div class="navbar-brand">
    <a  href="https://bulma.io">
      <img src="https://techatlast.com/wp-content/uploads/2012/06/web-3.0.png" alt="Bulma: a modern CSS framework based on Flexbox" width="224" height="56"></img>
    </a>
    <div class="navbar-burger" data-target="navbarExampleTransparentExample">
      <span></span>
      <span></span>
      <span></span>
    </div>
  </div>

  <div id="navbarExampleTransparentExample" class="navbar-menu">
    <div class="navbar-start">
      <a class="navbar-item" href="https://bulma.io/">
        Home
      </a>
      <div class="navbar-item has-dropdown is-hoverable">
        <a class="navbar-link" href="https://bulma.io/documentation/overview/start/">
          Links Úteis 
        </a>
        <div class="navbar-dropdown is-boxed">
          <a class="navbar-item" href="https://faucet-react-solidity.vercel.app/">
            Meu Faucet
          </a>
          <a class="navbar-item" href="https://faucet.egorfine.com/">
            Faucet 1
          </a>
          
          <a class="navbar-item" href="https://faucet.metamask.io/">
            Faucet 2
          </a>

          <a class="navbar-item" href="https://google.com">
            Contrato - Ropsten
          </a>
        </div>
      </div>
    </div>

    <div class="navbar-end">
      <div class="navbar-item">
        <div class="field is-grouped">
        <p class="control">
            <a class="button is-primary" href="https://www.linkedin.com/in/joao-paulo-pereira-de-ara%C3%BAjo-b24b63231/">
              <span class="icon">
                <i class="fas fa-download"></i>
              </span>
              <span>Linkedin</span>
            </a>
          </p>


                

        <p class="control">
            <a class="button is-primary" href="https://github.com/jpaulopereiraaraujo">
              <span class="icon">
                <i class="fas fa-download"></i>
              </span>
              <span>Github</span>
            </a>
          </p>
          
          <p class="control">
            <a class="button is-primary" href="https://github.com/jpaulopereiraaraujo/VendingMachineTokenJP/archive/refs/heads/main.zip">
              <span class="icon">
                <i class="fas fa-download"></i>
              </span>
              <span>Download</span>
            </a>
          </p>
        </div>
      </div>
    </div>
  </div>
</nav>

<div>
      <video loop autoPlay>
        <source
          src="https://file.lu/d/lvE/"
          type="video/mp4"
        />
        Your browser does not support the video tag.
      </video>
    </div>

    <div className="faucet-wrapper">
      <div className="faucet">
        <div className="is-flex is-align-items-center has-background-primary-light ">
        <span>
            <strong className ="mr-2"> Account: </strong>
        </span>
          {account ? 
          account: 
          <button
            className="button is-info mr-2"
            onClick={() => web3Api.provider.request({method:"eth_requestAccounts"})}
          > 
            Connect Wallet
          </button>
          
          }
        </div>

          <div class="container ">
            <div class="notification is-primary has-background-success-dark">
              
            <div className="balance-view  is-size-2 my-5">
          Machine Eth: <strong>{balance}</strong> ETH
        </div>
            
            </div>
          </div>

        
          <div class="container">
            <div class="notification is-primary">
              <div className="balance-view is-size-2 my-5">
          Yours Token: <strong>{balanceT}</strong> JTK
        </div>
            </div>
          </div>


        
       

        <button 
        disabled ={!account}
        onClick = {buyToken10}
        className="button is-primary mr-2 has-background-success-dark">
          Buy 10 Token
          </button>
        <button
        disabled ={!account}
        onClick = {sell10}
        className="button is-link">
          Sell 10 Token
          </button>
      </div>
    </div>
    
    </>
  );
}

export default App;
