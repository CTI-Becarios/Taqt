Imports System
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq

Module Main

    Sub Main()

        Dim token As String = GetToken()
        'Console.WriteLine(token)

        'Dim urlDevices As String = "https://api.taqt.com/companies/453/devices"
        Dim urlActions As String = "https://api.taqt.com/companies/453/actions?pagination=false&occurrence[after]=2024-03-14&order[serverDateTime]=DESC"
        'Dim urlEvents As String = "https://api.taqt.com/companies/453/events"

        Dim datosJson As JObject = GetDatos(token, urlActions)
        Console.WriteLine(datosJson)

        Console.ReadKey()
    End Sub

    Function GetToken() As String
        Dim url As String = "https://api.taqt.com/authentication_token"

        ' Crear objeto JSON para enviar en el cuerpo de la solicitud
        Dim jsonBody As New JObject()
        jsonBody.Add("email", "rsiles@ctisl.es")
        jsonBody.Add("password", "RSIL2024taqtTugev")


        ' Configurar el cliente HTTP
        Dim client As New HttpClient()

        ' Configurar el contenido de la solicitud
        Dim content As New StringContent(jsonBody.ToString(), Encoding.UTF8, "application/json")
 
        ' Realizar la solicitud POST
        Dim responseTask As Task(Of HttpResponseMessage) = client.PostAsync(url, content)
        responseTask.Wait()

        ' Obtener la respuesta
        Dim response As HttpResponseMessage = responseTask.Result

        ' Leer el contenido de la respuesta
        Dim responseContentTask As Task(Of String) = response.Content.ReadAsStringAsync()
        responseContentTask.Wait()

        Dim responseContent As JObject = JObject.Parse(responseContentTask.Result)

        ' Devolvemos el Token
        Return responseContent.GetValue("token").ToString()
    End Function

    Function GetDatos(ByRef token As String, ByRef url As String) As JObject

        ' Configurar el cliente HTTP
        Dim client As New HttpClient()

        ' Configurar el contenido de la solicitud
        'Dim content As New StringContent(jsonBody.ToString(), Encoding.UTF8, "application/json")
 
        ' Agregar el token al encabezado
        client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", token)

        ' Realizar la solicitud POST
        Dim responseTask As Task(Of HttpResponseMessage) = client.GetAsync(url)
        responseTask.Wait()

        ' Obtener la respuesta
        Dim response As HttpResponseMessage = responseTask.Result

        ' Leer el contenido de la respuesta
        Dim responseContentTask As Task(Of String) = response.Content.ReadAsStringAsync()
        responseContentTask.Wait()

        ' Parsear el contenido de la respuesta como un JObject
        Dim jsonResponse As JObject = JObject.Parse(responseContentTask.Result)

        ' Devolver el JSON como JObject
        Return jsonResponse
    End Function
End Module
