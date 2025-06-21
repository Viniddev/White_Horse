import "../../styles/globals.scss"
import "./main.scss";
import { Button } from "primereact/button";
import CardProdutos from "../cardProdutos/CardProdutos";
import { FiltroFormularioPrincipal } from "@/@types/components";
import DropDown from "../inputs/inputTypeDropDown";
import InputTypeCurrency from "../inputs/inputTypeCurrency";
import InputTypeText from "../inputs/inputTypeText";
import { EMPTY_FILTRO_FORMULARIO_PRINCIPAL } from "@/utils/constants/consts";
import React from "react";
import { products, TopicosDeDesenvolvimento } from "@/utils/mocks/products";
import {filtrarLista } from "../../hooks/useFormPesquisa";

export default function Main() {
  const [produtos, setProdutos] = React.useState(products);
  const [filtro, setFiltro] = React.useState<FiltroFormularioPrincipal>(EMPTY_FILTRO_FORMULARIO_PRINCIPAL);

  return (
    <main className="principalSection">
      <div className="flexRow conteinerFormularioPesquisa">
        <form action="" className="FormPesquisa">
          <h2 className="titleFormPesquisa">Pesquisa de Produtos:</h2>
          <div className="formgrid grid">
            <div className="field col-12 lg:col-4">
              <InputTypeText
                state={filtro.nome}
                setState={(newValue) =>
                  setFiltro((prevState) => ({
                    ...prevState,
                    nome: newValue,
                  }))
                }
                label={"Nome do curso:"}
                required={false}
                invalid={false}
              />
            </div>
            <div className="field col-12 lg:col-4">
              <InputTypeCurrency
                state={filtro.preco}
                setState={(newValue) => setFiltro((prevState) => ({
                  ...prevState,
                  preco: newValue,
                }))}
                label={"Preço até:"}
                required={false} 
                invalid={false}
              />
            </div>
            <div className="field col-12 lg:col-4">
              <DropDown
                list={TopicosDeDesenvolvimento}
                state={filtro.topico}
                setState={(newValue) => setFiltro((prevState) => ({
                  ...prevState,
                  topico: newValue,
                }))} 
                invalid={false}
              />
            </div>
            <div className="field col-12">
              <div className="conteinerSessaoBotoes">
                <div className="flexRow sessaoBotoes">
                  <Button
                    label="Limpar Filtro"
                    severity="warning"
                    className="botoesFiltro"
                    type="button"
                    outlined
                    onClick={() =>{
                      setFiltro(EMPTY_FILTRO_FORMULARIO_PRINCIPAL);
                      setProdutos(products);
                    }}
                  />
                  <Button
                    label="Filtrar"
                    severity="danger"
                    className="botoesFiltro"
                    type="button"
                    onClick={() => setProdutos(filtrarLista(produtos, filtro))}
                  />
                </div>
              </div>
            </div>
          </div>
        </form>
      </div>

      <div className="conteiner_promocoes">
        <h1 className="titlePromocoes">Promoções do dia:</h1>
        <div className="conteiner_cards">
          {produtos.map((element, index) => {
            return <CardProdutos prop={element} key={index} />;
          })}
        </div>
      </div>
    </main>
  );
}