<%
   String env = grails.util.Environment.current.name
%>
<!DOCTYPE html>
<html>
<head>
	<meta charset="UTF-8">
	<meta http-equiv="cache-control" content="no-cache" />
	<title>MCP</title>
</head>
<body>
    <h3>
        <b>Project:</b> <g:meta name="app.name"/><p>
    </h3>
    <h5>
	<b>Mode Version: </b>${env}<br>
	<b>App Version: </b><g:meta name="app.version"/><br>
	<b>Built with Grails: </b><g:meta name="app.grails.version"/><br>
        <b>DataSource: </b> ${grailsApplication.config.dataSource}<p>
    </h5>
</body>
</html>
