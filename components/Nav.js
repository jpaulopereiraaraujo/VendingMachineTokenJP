
function Nav() {


    return (

        <>
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
      <a id="linkhome" class="navbar-item" href="https://bulma.io/">
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

        
        </>
    )


}

export default Nav;