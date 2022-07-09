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
Namespace Vending Machine+React.Contracts.Math.ContractDefinition

    
    
    Public Partial Class MathDeployment
     Inherits MathDeploymentBase
    
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
    
    End Class

    Public Class MathDeploymentBase 
            Inherits ContractDeploymentMessage
        
        Public Shared DEFAULT_BYTECODE As String = "61015061003a600b82828239805160001a60731461002d57634e487b7160e01b600052600060045260246000fd5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600436106100355760003560e01c806342318e3d1461003a575b600080fd5b61004d61004836600461008a565b61005f565b60405190815260200160405180910390f35b600080606461006e84866100c2565b61007891906100e1565b6100829085610103565b949350505050565b6000806040838503121561009d57600080fd5b50508035926020909101359150565b634e487b7160e01b600052601160045260246000fd5b60008160001904831182151516156100dc576100dc6100ac565b500290565b6000826100fe57634e487b7160e01b600052601260045260246000fd5b500490565b600082821015610115576101156100ac565b50039056fea264697066735822122017f20bd3372eb68206b3a1a5635981ae7498d3617cbeb22136472adce0a07fb264736f6c634300080f0033"
        
        Public Sub New()
            MyBase.New(DEFAULT_BYTECODE)
        End Sub
        
        Public Sub New(ByVal byteCode As String)
            MyBase.New(byteCode)
        End Sub
        

    
    End Class    
    
    Public Partial Class PercentFunction
        Inherits PercentFunctionBase
    End Class

        <[Function]("percent", "uint256")>
    Public Class PercentFunctionBase
        Inherits FunctionMessage
    
        <[Parameter]("uint256", "a", 1)>
        Public Overridable Property [A] As BigInteger
        <[Parameter]("uint256", "b", 2)>
        Public Overridable Property [B] As BigInteger
    
    End Class
    
    
    Public Partial Class PercentOutputDTO
        Inherits PercentOutputDTOBase
    End Class

    <[FunctionOutput]>
    Public Class PercentOutputDTOBase
        Implements IFunctionOutputDTO
        
        <[Parameter]("uint256", "", 1)>
        Public Overridable Property [ReturnValue1] As BigInteger
    
    End Class
End Namespace
