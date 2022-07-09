
const tokenContract = artifacts.require("JPToken")
module.exports = function(deployer){
    deployer.deploy(tokenContract)
}
