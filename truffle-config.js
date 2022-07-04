var HDWalletProvider = require("truffle-hdwallet-provider");

module.exports = {
  contracts_build_directory:"./public/contracts",


  networks: {
 
    development: {
     host: "127.0.0.1",     // Localhost (default: none)
     port: 8545,            // Standard Ethereum port (default: none)
     network_id: "*",       // Any network (default: none)
    },

    ropsten: {
      networkCheckTimeout: 999999,
      provider: function() {
        return new HDWalletProvider(
          "scrub warrior general run pigeon strategy admit crunch pupil away height word", 
          "https://ropsten.infura.io/v3/18eac1d72d2e48078937e08501b7eae6")
      },
      network_id: 3,
      gas: 4000000      //make sure this gas allocation isn't over 4M, which is the max
    }
    
  },


  // Configure your compilers
  compilers: {
    solc: {
      version: "0.8.14",      // Fetch exact version from solc-bin (default: truffle's version)
      
    }
  },
};
