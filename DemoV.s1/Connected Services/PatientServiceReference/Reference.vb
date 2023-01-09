﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.Serialization

Namespace PatientServiceReference
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute(Name:="Patient", [Namespace]:="http://schemas.datacontract.org/2004/07/VBNetWCFDemo"),  _
     System.SerializableAttribute()>  _
    Partial Public Class Patient
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
        
        <System.NonSerializedAttribute()>  _
        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private AddressField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private DateOfBirthField As Date
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private IDField As System.Guid
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private NRICField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private NameField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private PhoneNumberField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private PictureField As String
        
        <Global.System.ComponentModel.BrowsableAttribute(false)>  _
        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set
                Me.extensionDataField = value
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property Address() As String
            Get
                Return Me.AddressField
            End Get
            Set
                If (Object.ReferenceEquals(Me.AddressField, value) <> true) Then
                    Me.AddressField = value
                    Me.RaisePropertyChanged("Address")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property DateOfBirth() As Date
            Get
                Return Me.DateOfBirthField
            End Get
            Set
                If (Me.DateOfBirthField.Equals(value) <> true) Then
                    Me.DateOfBirthField = value
                    Me.RaisePropertyChanged("DateOfBirth")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property ID() As System.Guid
            Get
                Return Me.IDField
            End Get
            Set
                If (Me.IDField.Equals(value) <> true) Then
                    Me.IDField = value
                    Me.RaisePropertyChanged("ID")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property NRIC() As String
            Get
                Return Me.NRICField
            End Get
            Set
                If (Object.ReferenceEquals(Me.NRICField, value) <> true) Then
                    Me.NRICField = value
                    Me.RaisePropertyChanged("NRIC")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property Name() As String
            Get
                Return Me.NameField
            End Get
            Set
                If (Object.ReferenceEquals(Me.NameField, value) <> true) Then
                    Me.NameField = value
                    Me.RaisePropertyChanged("Name")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property PhoneNumber() As String
            Get
                Return Me.PhoneNumberField
            End Get
            Set
                If (Object.ReferenceEquals(Me.PhoneNumberField, value) <> true) Then
                    Me.PhoneNumberField = value
                    Me.RaisePropertyChanged("PhoneNumber")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property Picture() As String
            Get
                Return Me.PictureField
            End Get
            Set
                If (Object.ReferenceEquals(Me.PictureField, value) <> true) Then
                    Me.PictureField = value
                    Me.RaisePropertyChanged("Picture")
                End If
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="PatientServiceReference.IPatientService")>  _
    Public Interface IPatientService
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IPatientService/GetPatients", ReplyAction:="http://tempuri.org/IPatientService/GetPatientsResponse")>  _
        Function GetPatients(ByVal clinicId As System.Guid) As PatientServiceReference.Patient()
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IPatientService/GetPatients", ReplyAction:="http://tempuri.org/IPatientService/GetPatientsResponse")>  _
        Function GetPatientsAsync(ByVal clinicId As System.Guid) As System.Threading.Tasks.Task(Of PatientServiceReference.Patient())
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IPatientService/DeletePatient", ReplyAction:="http://tempuri.org/IPatientService/DeletePatientResponse")>  _
        Sub DeletePatient(ByVal deletedId As System.Guid)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IPatientService/DeletePatient", ReplyAction:="http://tempuri.org/IPatientService/DeletePatientResponse")>  _
        Function DeletePatientAsync(ByVal deletedId As System.Guid) As System.Threading.Tasks.Task
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IPatientService/GetPatientById", ReplyAction:="http://tempuri.org/IPatientService/GetPatientByIdResponse")>  _
        Function GetPatientById(ByVal patientId As System.Guid) As PatientServiceReference.Patient
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IPatientService/GetPatientById", ReplyAction:="http://tempuri.org/IPatientService/GetPatientByIdResponse")>  _
        Function GetPatientByIdAsync(ByVal patientId As System.Guid) As System.Threading.Tasks.Task(Of PatientServiceReference.Patient)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IPatientService/UpdatePatientById", ReplyAction:="http://tempuri.org/IPatientService/UpdatePatientByIdResponse")>  _
        Function UpdatePatientById(ByVal patientId As System.Guid, ByVal nric As String, ByVal name As String, ByVal dob As Date, ByVal address As String, ByVal phone As String, ByVal picture As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IPatientService/UpdatePatientById", ReplyAction:="http://tempuri.org/IPatientService/UpdatePatientByIdResponse")>  _
        Function UpdatePatientByIdAsync(ByVal patientId As System.Guid, ByVal nric As String, ByVal name As String, ByVal dob As Date, ByVal address As String, ByVal phone As String, ByVal picture As String) As System.Threading.Tasks.Task(Of Boolean)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IPatientService/AddNewPatient", ReplyAction:="http://tempuri.org/IPatientService/AddNewPatientResponse")>  _
        Function AddNewPatient(ByVal nric As String, ByVal name As String, ByVal dob As Date, ByVal address As String, ByVal phone As String, ByVal picture As String) As Boolean
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IPatientService/AddNewPatient", ReplyAction:="http://tempuri.org/IPatientService/AddNewPatientResponse")>  _
        Function AddNewPatientAsync(ByVal nric As String, ByVal name As String, ByVal dob As Date, ByVal address As String, ByVal phone As String, ByVal picture As String) As System.Threading.Tasks.Task(Of Boolean)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IPatientServiceChannel
        Inherits PatientServiceReference.IPatientService, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class PatientServiceClient
        Inherits System.ServiceModel.ClientBase(Of PatientServiceReference.IPatientService)
        Implements PatientServiceReference.IPatientService
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function GetPatients(ByVal clinicId As System.Guid) As PatientServiceReference.Patient() Implements PatientServiceReference.IPatientService.GetPatients
            Return MyBase.Channel.GetPatients(clinicId)
        End Function
        
        Public Function GetPatientsAsync(ByVal clinicId As System.Guid) As System.Threading.Tasks.Task(Of PatientServiceReference.Patient()) Implements PatientServiceReference.IPatientService.GetPatientsAsync
            Return MyBase.Channel.GetPatientsAsync(clinicId)
        End Function
        
        Public Sub DeletePatient(ByVal deletedId As System.Guid) Implements PatientServiceReference.IPatientService.DeletePatient
            MyBase.Channel.DeletePatient(deletedId)
        End Sub
        
        Public Function DeletePatientAsync(ByVal deletedId As System.Guid) As System.Threading.Tasks.Task Implements PatientServiceReference.IPatientService.DeletePatientAsync
            Return MyBase.Channel.DeletePatientAsync(deletedId)
        End Function
        
        Public Function GetPatientById(ByVal patientId As System.Guid) As PatientServiceReference.Patient Implements PatientServiceReference.IPatientService.GetPatientById
            Return MyBase.Channel.GetPatientById(patientId)
        End Function
        
        Public Function GetPatientByIdAsync(ByVal patientId As System.Guid) As System.Threading.Tasks.Task(Of PatientServiceReference.Patient) Implements PatientServiceReference.IPatientService.GetPatientByIdAsync
            Return MyBase.Channel.GetPatientByIdAsync(patientId)
        End Function
        
        Public Function UpdatePatientById(ByVal patientId As System.Guid, ByVal nric As String, ByVal name As String, ByVal dob As Date, ByVal address As String, ByVal phone As String, ByVal picture As String) As Boolean Implements PatientServiceReference.IPatientService.UpdatePatientById
            Return MyBase.Channel.UpdatePatientById(patientId, nric, name, dob, address, phone, picture)
        End Function
        
        Public Function UpdatePatientByIdAsync(ByVal patientId As System.Guid, ByVal nric As String, ByVal name As String, ByVal dob As Date, ByVal address As String, ByVal phone As String, ByVal picture As String) As System.Threading.Tasks.Task(Of Boolean) Implements PatientServiceReference.IPatientService.UpdatePatientByIdAsync
            Return MyBase.Channel.UpdatePatientByIdAsync(patientId, nric, name, dob, address, phone, picture)
        End Function
        
        Public Function AddNewPatient(ByVal nric As String, ByVal name As String, ByVal dob As Date, ByVal address As String, ByVal phone As String, ByVal picture As String) As Boolean Implements PatientServiceReference.IPatientService.AddNewPatient
            Return MyBase.Channel.AddNewPatient(nric, name, dob, address, phone, picture)
        End Function
        
        Public Function AddNewPatientAsync(ByVal nric As String, ByVal name As String, ByVal dob As Date, ByVal address As String, ByVal phone As String, ByVal picture As String) As System.Threading.Tasks.Task(Of Boolean) Implements PatientServiceReference.IPatientService.AddNewPatientAsync
            Return MyBase.Channel.AddNewPatientAsync(nric, name, dob, address, phone, picture)
        End Function
    End Class
End Namespace
