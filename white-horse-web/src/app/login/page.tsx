"use client";
import "./login.scss";
import "../../styles/globals.scss";
import { SetStateAction } from "react";
import React from "react";
import InputTypeText from "@/components/inputs/input_type_text";
import InputTypePassword from "@/components/inputs/input_type_password";
import { Button } from "primereact/button";
import Link from "next/link";
import { CADASTRO } from "@/utils/front_end_urls/urls";

export default function Login() {
  const [login, setLogin] = React.useState<string>("");

  return (
    <section className="ConteinerTelaLogin flexRow">
      <div className="boxLogin">
        <div className="secaoLogo flexRow">
          <img
            src="./logo_principal_sem_fundo.png"
            alt="Logo Principal"
            className="imagem_logo"
          />
        </div>
        <div className="secaoFormLogin flexColumn">
          <form action="" className="formLogin flexColumn">
            <InputTypeText state={login} setState={setLogin} label={"User"} />

            <InputTypePassword
              state={login}
              setState={setLogin}
              label={"password"}
            />

            <div className="sessaoEsqueciASenha">
              <p>
                <Link href="https://www.youtube.com/watch?v=4TwQa4lpYCg">
                  esqueci minha senha
                </Link>
              </p>
            </div>

            <div className="sessaoBotoes">
              <Link href={CADASTRO}>
                <Button label="Cadastrar" outlined severity="warning" />
              </Link>
              <Button label="Submit" />
            </div>
          </form>
        </div>
      </div>
    </section>
  );
}
