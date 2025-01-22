import "../../styles/globals.scss"
import "./main.scss";

export default function Main(){
    return (
      <main className="flexStart">
        <div className="conteiner_promocoes">
          <h1 className="titlePromocoes">Promoções do dia:</h1>

          {/* <div className="conteiner_cards">
            <CardProdutos />
            <CardProdutos />
            <CardProdutos />
          </div> */}

        </div>
      </main>
    );
}