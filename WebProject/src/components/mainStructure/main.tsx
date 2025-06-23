import "../../styles/globals.scss"
import "./main.scss";
import { Button } from "primereact/button";
import React from "react";
import { Editor, EditorTextChangeEvent } from "primereact/editor";

export default function Main() {
  const [text, setText] = React.useState<string>("");

  return (
    <main className="principalSection">
      <div className="flexRow conteinerFormularioPesquisa">
        <form className="FormPesquisa">
          <h2 className="titleFormPesquisa">Tell us what are you thinking!</h2>
          <div className="formgrid grid">
            <div className="field col-12 lg:col-12">
              <div className="card conteinerCardInputText">
                <div className="cardInputTextArea">
                  <Editor
                    value={text}
                    onTextChange={(e: EditorTextChangeEvent) =>
                      setText(e.htmlValue!)
                    }
                    style={{
                      height: "85px",
                      color: "black",
                      border: "none"
                    }}
                  />
                </div>
              </div>
            </div>
            <div className="field col-12">
              <div className="conteinerSessaoBotoes">
                <div className="flexRow sessaoBotoes">
                  <Button
                    label="Publicar"
                    severity="danger"
                    className="botoesFiltro"
                    type="button"
                    onClick={() => console.log(text)}
                  />
                </div>
              </div>
            </div>
          </div>
        </form>
      </div>
    </main>
  );
}