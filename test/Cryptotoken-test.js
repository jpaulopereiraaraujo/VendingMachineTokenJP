const contract = require("@truffle/contract");
const { assert } = require("chai");

var CryptoToken = artifacts.require("./CryptoToken.sol");

contract('CryptoToken', () => {
    
    it("1 Test Total Supply", async ()=> {
      var cryInstance;
      before(async() => {
        cryInstance = await JPToken.deployed();
      })
      
      
      const totalSupply = await cryInstance.totalSupply();
      
      const expectedSupply = 3000000000;
      
      assert.equal(expectedSupply, totalSupply.then(b => {return b.toNumber()}), "Total supply diverges from contract")
    });
  });
