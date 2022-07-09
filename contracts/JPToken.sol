// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;

interface IERC20 {
    function totalSupply() external view returns (uint256);
    function balanceOf(address account) external view returns (uint256);
    event Transfer(address from, address to, uint256 value);
    
}
    contract JPToken is IERC20 {


    //Properties
    string public constant name = "JPToken";
    string public constant symbol = "JTK";
    uint8 public constant decimals = 3; //Default dos exemplos é sempre 18
    uint256 private totalsupply;
    uint256 private stockJPToken;
    address private owner;
    address[] private tokenOwners;

    mapping(address => uint256) private addressToBalance;

    modifier isOwner() {
        require(address(msg.sender) == owner, "Sender is not owner!");
        _;
    }

    //Constructor
    constructor() {
        uint256 total = 3000000000;
        totalsupply = total;
        stockJPToken = total;
        owner = msg.sender;
        addressToBalance[owner] = stockJPToken;
        tokenOwners.push(owner);
    }

    //Public Functions
    function totalSupply() public view override returns (uint256) {
        return totalsupply;
    }

    function showStockJPT() public view returns(uint256)  {
        return stockJPToken;
    }

    function balanceOf(address tokenOwner) public view override returns (uint256){
        return addressToBalance[tokenOwner];
    }


    function transfer(address receiver, uint256 quantity) private returns (bool){
        require(quantity <= addressToBalance[owner],"Insufficient Balance to Transfer");
        addressToBalance[owner] = addressToBalance[owner] - quantity;
        addressToBalance[receiver] = addressToBalance[receiver] + quantity;
        tokenOwners.push(receiver);
        emit Transfer(owner, receiver, quantity);
        return true;
    }

    function buy10() public payable{
        require(msg.value == 1 ether);
        require(balanceOf(owner) >= 10, "Not enough JToken in stock to fulfill purchase request.");
        transfer(msg.sender, 10);
        emit Transfer(address(this), msg.sender, 10);
    }

    function buy20() public payable{
        require(msg.value == 2 ether);
        require(balanceOf(owner) >= 20, "Not enough JToken in stock to fulfill purchase request.");
        transfer(msg.sender, 20);
        emit Transfer(address(this), msg.sender, 20);
    }
    
    
    function sell10() public{
        uint256 valueToPay;
        valueToPay = 900000000000000000;
        addressToBalance[owner] = addressToBalance[owner] + 10;
        addressToBalance[msg.sender] = addressToBalance[msg.sender] - 10;
        require(balanceOf(msg.sender) >= 10, "Not enough JToken to trade for ether.");
        require(address(this).balance >= valueToPay, "Not enough ethers to pay for this transaction.");
        payable(msg.sender).transfer(valueToPay);
        
        emit Transfer(msg.sender, address(this), 10);
    }

    function restockEth() public payable isOwner{
        require(msg.value > 0,"You can't restock 0 or less Ethers.");
    }

    function contractBalance () public view returns(uint256) {
        return address(this).balance;
    }

    function toWithdraw() public payable isOwner{
        payable(msg.sender).transfer(address(this).balance);
        emit Transfer(address(this), msg.sender, address(this).balance);
    }
}
//const instance = await JPToken.deployed()
//instance.buy10({from:accounts[1], value: "1000000000000000000"})
//instance.contractBalance().then(b => { return b.toString()})
//instance.balanceOf('0x7d4E11705806a4fCbF0A8C7a9F747EaA87351312').then(b => {return b.toString()})
//instance.balanceOf('0xC22e7B41F605cf5Cae65F81F3c9AC7B5740d0e89').then(b => {return b.toString()})

//