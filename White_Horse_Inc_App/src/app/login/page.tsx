"use client";
import "./login.scss";
import "../../styles/globals.scss";
import React from "react";
import InputTypeText from "@/components/inputs/inputTypeText";
import InputTypePassword from "@/components/inputs/inputTypePassword";
import { Button } from "primereact/button";
import Link from "next/link";
import { CADASTRO } from "@/utils/frontEndUrls/urls";;
import { Toast } from "primereact/toast";
import { usePageLogin } from "./usePageLogin";

export default function Login() {
  const {toast, loginInformations, setLoginInformations, Isloading, IsInvalid, FetchLogin} = usePageLogin();

  return (
    <section className="ConteinerTelaLogin">
      <Toast ref={toast} />
      <div className="boxLogin">
        <div className="secaoLogo flexRow">
          <img
            src="./logo_principal_sem_fundo.png"
            alt="Logo Principal"
            className="imagem_logo"
          />
        </div>
        <div className="secaoFormLogin flexColumn">
          <form className="formLogin flexColumn" onSubmit={FetchLogin}>
            <InputTypeText
              state={loginInformations.Email}
              setState={(newValue) =>
                setLoginInformations((prevState) => ({
                  ...prevState,
                  Email: newValue,
                }))
              }
              label="Email"
              required={true}
              invalid={IsInvalid}
            />
            <InputTypePassword
              state={loginInformations.Password}
              setState={(newValue) =>
                setLoginInformations((prevState) => ({
                  ...prevState,
                  Password: newValue,
                }))
              }
              label="Password"
              required={true}
              invalid={IsInvalid}
            />

            <div className="sessaoEsqueciASenha">
              <p>
                <Link
                  href="https://www.youtube.com/watch?v=4TwQa4lpYCg"
                  className="EsqueciMinhaSenha"
                >
                  esqueci minha senha
                </Link>
              </p>
            </div>

            <div className="sessaoBotoes">
              <Link href={CADASTRO}>
                <Button label="Cadastrar" outlined severity="warning" />
              </Link>
              <Button label="Submit" type="submit" loading={Isloading} />
            </div>
          </form>
        </div>
      </div>
    </section>
  );
}
