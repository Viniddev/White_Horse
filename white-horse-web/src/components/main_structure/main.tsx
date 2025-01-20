import "../../styles/globals.scss"
import CardProdutos from "../card_produtos/CardProdutos";
import { MainTitle } from "../custom/title_aplication";
import "./main.scss";

export default function Main(){
    return (
      <main className="flexStart">
        <div className="conteiner_promocoes">
          <MainTitle hg="2rem" align="left">
            Promoções do dia:
          </MainTitle>

          <hr className="separador"/>

          <div className="conteiner_cards">
            <CardProdutos />
            <CardProdutos />
            <CardProdutos />
            <CardProdutos />
            <CardProdutos />
          </div>
        </div>
      </main>
    );
}