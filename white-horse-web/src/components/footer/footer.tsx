import "../../styles/globals.scss";
import "./footer.scss";

export default function Footer(){
    return (
      <section className="footerLayout">
        <p className="textFooter">
          ©Todos os direitos reservados a <a href="https://www.linkedin.com/in/vin%C3%ADcius-dias-rodrigues/" target="_blank">Vinícius Dias Rodrigues.</a>
        </p>
        <h1 className="textFooter">Contato: (31) 99554-2943</h1>
      </section>
    );
}