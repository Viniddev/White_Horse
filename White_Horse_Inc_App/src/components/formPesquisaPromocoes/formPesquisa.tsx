import { FiltroFormularioPrincipal, Prop } from "@/@types/components";
import "./formPesquisa.scss";
import "../../styles/globals.scss";
import InputTypeText from "../inputs/inputTypeText";
import React from "react";
import { EMPTY_FILTRO_FORMULARIO_PRINCIPAL } from "@/utils/constants/consts";
import { Button } from "primereact/button";
import DropDown from "../inputs/inputTypeDropDown";
import InputTypeCurrency from "../inputs/inputTypeCurrency";
import { TopicosDeDesenvolvimento } from "@/utils/mocks/products";
import orderByDescendingFunction from "./formPesquisa";

export default function FormularioPesquisa(Prop: Prop) {
  const [filtro, setFiltro] = React.useState<FiltroFormularioPrincipal>( EMPTY_FILTRO_FORMULARIO_PRINCIPAL );

  return (
    <div className="flexRow conteinerFormularioPesquisa">
      <form action="" className="FormPesquisa">
        <h2 className="titleFormPesquisa">Pesquisa de Produtos</h2>
        <div className="formgrid grid">
          <div className="field col-12 lg:col-4">
            <InputTypeText
              state={filtro.nome}
              setState={(newValue) =>
                setFiltro((prevState) => ({
                  ...prevState,
                  name: newValue,
                }))
              }
              label={"Nome do curso:"}
              required={false}
            />
          </div>
          <div className="field col-12 lg:col-4">
            <InputTypeCurrency
              state={filtro.preco}
              setState={(newValue) =>
                setFiltro((prevState) => ({
                  ...prevState,
                  preco: newValue,
                }))
              }
              label={"Preco até:"}
              required={false}
            />
          </div>
          <div className="field col-12 lg:col-4">
            <DropDown list={TopicosDeDesenvolvimento} />
          </div>
          <div className="field col-12">
            <div className="conteinerSessaoBotoes">
              <div className="flexRow sessaoBotoes">
                <Button
                  label="Limpar Filtro"
                  severity="warning"
                  outlined
                  className="botoesFiltro"
                  type="button"
                  onClick={() => Prop.setList(orderByDescendingFunction(Prop.list))}
                />
                <Button
                  label="Filtrar"
                  severity="danger"
                  className="botoesFiltro"
                  type="button"
                />
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}
