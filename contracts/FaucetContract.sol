// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

import "./Owned.sol";
import "./Logger.sol";

contract Faucet is Owned, Logger{

    //storage variables
    uint public numOfFunders;
    
    mapping(address => bool) public funders;
    mapping(uint => address) public rgtFunders;

    

    //modifiers

    

    modifier limitWithdraw(uint withdrawAmount) {

    require(withdrawAmount <= 100000000000000000,"You can only withdraw less than 0.1 ether");
    _;
    
    }
    
    //função receive
    receive() external payable {}

    function emitLog() public override pure returns(bytes32){
        return "Hello World";
    }

    function addFunds() external payable {
        address funder = msg.sender;
        

        if (!funders[funder]){
            uint index = numOfFunders++;
            funders[funder] = true;
            rgtFunders[index] = funder;
        }
    }

    function withdraw(uint withdrawAmount) external limitWithdraw(withdrawAmount){
        
        payable(msg.sender).transfer(withdrawAmount);

    }

    function getAllFunders() external view isOwner returns (address[] memory){
        address[] memory _funders = new address[](numOfFunders);
        for(uint i = 0; i < numOfFunders; i++){
            _funders[i] = rgtFunders[i];
        }

        return _funders;

    }

    function getFunderAtIndex(uint8 index) external view isOwner returns(address){
        
        return rgtFunders[index];

    }



}

//Comandos do truffle console

//const instance = await Faucet.deployed()
//instance.addFunds({from:accounts[1], value:"2000000000000000000"})
//instance.addFunds({from:accounts[2], value:"2000000000000000000"})

//instance.withdraw("500000000000000000", {from: accounts[1]})
//instance.getFunderAtIndex()
//instance.getAllFunders()
//