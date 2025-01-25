import "../../styles/globals.scss"
import CardProdutos from "../card_produtos/CardProdutos";
import "./main.scss";
import { products } from "@/utils/mocks/products";

export default function Main(){
    return (
      <main className="principal_section">
        <div className="conteiner_promocoes">

          <h1 className="titlePromocoes">Promoções do dia:</h1>
          <div className="conteiner_cards">
            {products.map((element, index) => {
              return <CardProdutos prop={element} key={index} />;
            })}
          </div>

        </div>
      </main>
    );
}