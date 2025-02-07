"use client";
import "./login.scss";
import "../../styles/globals.scss";
import { FormEvent, useRef } from "react";
import React from "react";
import InputTypeText from "@/components/inputs/inputTypeText";
import InputTypePassword from "@/components/inputs/inputTypePassword";
import { Button } from "primereact/button";
import Link from "next/link";
import { CADASTRO } from "@/utils/frontEndUrls/urls";
import { fetchLoginInformations } from "@/routes/baseRequest";
import { retornoLoginComToken } from "@/@types/resp";
import { Toast } from "primereact/toast";

export default function Login() {
  const toast = useRef<Toast>(null);
  const [login, setLogin] = React.useState<string>("");
  const [password, setPassword] = React.useState<string>("");
  const [Isloading, setIsLoading] = React.useState<boolean>(false);

  async function FetchLogin(e: FormEvent<HTMLFormElement>) {
    e.preventDefault();

    if (login != "" && password != "") {
      setIsLoading(true);

      var retorno: retornoLoginComToken = await fetchLoginInformations(
        login,
        password
      );

      toast?.current?.show({
        severity: "info",
        summary: "Info",
        detail: retorno.message,
      });

      setIsLoading(false);
    }
  }

  return (
    <section className="ConteinerTelaLogin flexRow">
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
              state={login}
              setState={setLogin}
              label={"User"}
              required={false}
            />

            <InputTypePassword
              state={password}
              setState={setPassword}
              label={"password"}
              required={false}
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
