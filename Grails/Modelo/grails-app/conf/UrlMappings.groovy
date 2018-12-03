class UrlMappings {

	static mappings = {
        "/$controller/$action?/$id?(.$format)?"{
            constraints {
                // apply constraints here
            }
        }
        
        "/api/ping"(controller: "ping", action: "index") {}

        "/"(view:"/index")
        "500"(view:'/error')
	}
}
