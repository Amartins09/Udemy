package modelo

import grails.test.mixin.TestFor
import spock.lang.Specification

/**
 * See the API for {@link grails.test.mixin.web.ControllerUnitTestMixin} for usage instructions
 */
@TestFor(PingController)
class PingControllerSpec extends Specification {

    def setup() {
    }

    def cleanup() {
    }

    void "Valid Response"() {
        given:
        
        when: 
            controller.index()
        then
            response.text == "Pong"
    }

    void "Invalid Response"() {
        given:
        
        when: 
            controller.index()
        then
            response.text != "Ping"
    }
}
