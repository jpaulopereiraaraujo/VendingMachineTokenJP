Imports System
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Numerics
Imports Nethereum.Hex.HexTypes
Imports Nethereum.ABI.FunctionEncoding.Attributes
Imports Nethereum.Web3
Imports Nethereum.RPC.Eth.DTOs
Imports Nethereum.Contracts.CQS
Imports Nethereum.Contracts.ContractHandlers
Imports Nethereum.Contracts
Imports System.Threading
Imports Vending Machine+React.Contracts.Math.ContractDefinition
Namespace Vending Machine+React.Contracts.Math


    Public Partial Class MathService
    
    
        Public Shared Function DeployContractAndWaitForReceiptAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal mathDeployment As MathDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of TransactionReceipt)
        
            Return web3.Eth.GetContractDeploymentHandler(Of MathDeployment)().SendRequestAndWaitForReceiptAsync(mathDeployment, cancellationTokenSource)
        
        End Function
         Public Shared Function DeployContractAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal mathDeployment As MathDeployment) As Task(Of String)
        
            Return web3.Eth.GetContractDeploymentHandler(Of MathDeployment)().SendRequestAsync(mathDeployment)
        
        End Function
        Public Shared Async Function DeployContractAndGetServiceAsync(ByVal web3 As Nethereum.Web3.Web3, ByVal mathDeployment As MathDeployment, ByVal Optional cancellationTokenSource As CancellationTokenSource = Nothing) As Task(Of MathService)
        
            Dim receipt = Await DeployContractAndWaitForReceiptAsync(web3, mathDeployment, cancellationTokenSource)
            Return New MathService(web3, receipt.ContractAddress)
        
        End Function
    
        Protected Property Web3 As Nethereum.Web3.Web3
        
        Public Property ContractHandler As ContractHandler
        
        Public Sub New(ByVal web3 As Nethereum.Web3.Web3, ByVal contractAddress As String)
            Web3 = web3
            ContractHandler = web3.Eth.GetContractHandler(contractAddress)
        End Sub
    
        Public Function PercentQueryAsync(ByVal percentFunction As PercentFunction, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            Return ContractHandler.QueryAsync(Of PercentFunction, BigInteger)(percentFunction, blockParameter)
        
        End Function

        
        Public Function PercentQueryAsync(ByVal [a] As BigInteger, ByVal [b] As BigInteger, ByVal Optional blockParameter As BlockParameter = Nothing) As Task(Of BigInteger)
        
            Dim percentFunction = New PercentFunction()
                percentFunction.A = [a]
                percentFunction.B = [b]
            
            Return ContractHandler.QueryAsync(Of PercentFunction, BigInteger)(percentFunction, blockParameter)
        
        End Function


    
    End Class

End Namespace
