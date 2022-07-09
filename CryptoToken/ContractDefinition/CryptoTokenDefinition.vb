Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Imports Nethereum.Web3
Imports Nethereum.RPC.Eth.DTOs
Imports Nethereum.Contracts.CQS
Imports Nethereum.Contracts
Imports System.Threading
Namespace Vending Machine+React.Contracts.CryptoToken.ContractDefinition

    
    
    Public Partial Class CryptoTokenDeployment
     Inherits CryptoTokenDeploymentBase
    
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
    
    End Class

    Public Class CryptoTokenDeploymentBase 
            Inherits ContractDeploymentMessage
        
        Public Shared DEFAULT_BYTECODE As String = "608060405234801561001057600080fd5b5063b2d05e006000818155600180546001600160a01b031990811633908117835583526003602052604083209390935580546002805492830181559092527f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ace0180549092166001600160a01b039190911617905561043f806100936000396000f3fe608060405234801561001057600080fd5b50600436106100625760003560e01c806306fdde031461006757806318160ddd146100a7578063313ce567146100b957806370a08231146100d357806395d89b41146100fc578063a9059cbb1461011e575b600080fd5b6100916040518060400160405280600b81526020016a21b93cb83a37aa37b5b2b760a91b81525081565b60405161009e9190610307565b60405180910390f35b6000545b60405190815260200161009e565b6100c1600381565b60405160ff909116815260200161009e565b6100ab6100e1366004610378565b6001600160a01b031660009081526003602052604090205490565b6100916040518060400160405280600381526020016243525960e81b81525081565b61013161012c36600461039a565b610141565b604051901515815260200161009e565b6001546000906001600160a01b0316331461019a5760405162461bcd60e51b815260206004820152601460248201527353656e646572206973206e6f74206f776e65722160601b60448201526064015b60405180910390fd5b6001546001600160a01b03166000908152600360205260409020548211156102045760405162461bcd60e51b815260206004820181905260248201527f496e73756666696369656e742042616c616e636520746f205472616e736665726044820152606401610191565b6001546001600160a01b031660009081526003602052604090205461022a9083906103da565b6001546001600160a01b03908116600090815260036020526040808220939093559085168152205461025d9083906103f1565b6001600160a01b038481166000818152600360209081526040808320959095556002805460018082018355919093527f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ace90920180546001600160a01b0319168417905590548451931683528201529081018390527fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef9060600160405180910390a150600192915050565b600060208083528351808285015260005b8181101561033457858101830151858201604001528201610318565b81811115610346576000604083870101525b50601f01601f1916929092016040019392505050565b80356001600160a01b038116811461037357600080fd5b919050565b60006020828403121561038a57600080fd5b6103938261035c565b9392505050565b600080604083850312156103ad57600080fd5b6103b68361035c565b946020939093013593505050565b634e487b7160e01b600052601160045260246000fd5b6000828210156103ec576103ec6103c4565b500390565b60008219821115610404576104046103c4565b50019056fea264697066735822122039bc44f26ad8fd42dbe8b6efa3944f403122f7f80d680ef9151b2ef92992457364736f6c634300080f0033"
        
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
        

    
    End Class    
    
    Public Partial Class BalanceOfFunction
        Inherits BalanceOfFunctionBase
    End Class

        <[Function]("balanceOf", "uint256")>
    Public Class BalanceOfFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "tokenOwner", 1)>
        Public Overridable Property [TokenOwner] As String
    
    End Class
    
    
    Public Partial Class DecimalsFunction
        Inherits DecimalsFunctionBase
    End Class

        <[Function]("decimals", "uint8")>
    Public Class DecimalsFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class NameFunction
        Inherits NameFunctionBase
    End Class

        <[Function]("name", "string")>
    Public Class NameFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class SymbolFunction
        Inherits SymbolFunctionBase
    End Class

        <[Function]("symbol", "string")>
    Public Class SymbolFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class TotalSupplyFunction
        Inherits TotalSupplyFunctionBase
    End Class

        <[Function]("totalSupply", "uint256")>
    Public Class TotalSupplyFunctionBase
        Inherits FunctionMessage
    

    
    End Class
    
    
    Public Partial Class TransferFunction
        Inherits TransferFunctionBase
    End Class

        <[Function]("transfer", "bool")>
    Public Class TransferFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("address", "receiver", 1)>
        Public Overridable Property [Receiver] As String
        <[Parameter]("uint256", "quantity", 2)>
        Public Overridable Property [Quantity] As BigInteger
    
    End Class
    
    
    Public Partial Class TransferEventDTO
        Inherits TransferEventDTOBase
    End Class

    <[Event]("Transfer")>
    Public Class TransferEventDTOBase
        Implements IEventDTO
        
        <[Parameter]("address", "from", 1, false)>
        Public Overridable Property [From] As String
        <[Parameter]("address", "to", 2, false)>
        Public Overridable Property [To] As String
        <[Parameter]("uint256", "value", 3, false)>
        Public Overridable Property [Value] As BigInteger
    
    End Class    
    
    Public Partial Class BalanceOfOutputDTO
        Inherits BalanceOfOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class BalanceOfOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("uint256", "", 1)>
        Public Overridable Property [ReturnValue1] As BigInteger
    
    End Class    
    
    Public Partial Class DecimalsOutputDTO
        Inherits DecimalsOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class DecimalsOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("uint8", "", 1)>
        Public Overridable Property [ReturnValue1] As Byte
    
    End Class    
    
    Public Partial Class NameOutputDTO
        Inherits NameOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class NameOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("string", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class SymbolOutputDTO
        Inherits SymbolOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class SymbolOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("string", "", 1)>
        Public Overridable Property [ReturnValue1] As String
    
    End Class    
    
    Public Partial Class TotalSupplyOutputDTO
        Inherits TotalSupplyOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class TotalSupplyOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("uint256", "", 1)>
        Public Overridable Property [ReturnValue1] As BigInteger
    
    End Class    
    

End Namespace
