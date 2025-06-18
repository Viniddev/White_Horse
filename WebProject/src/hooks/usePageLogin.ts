import { FormEvent, useRef, useState } from "react";
import { PROFILE } from "@/utils/frontEndUrls/urls";
import { retornoLoginComToken } from "@/@types/resp";
import { LoginReq } from "@/@types/req";
import { Toast } from "primereact/toast";
import { fetchLoginInformations } from "../routes/BaseRequest";

export function usePageLogin() {
  const toast = useRef<Toast>(null);
  const [loginInformations, setLoginInformations] = useState<LoginReq>({Email: "", Password: ""});
  const [Isloading, setIsLoading] = useState<boolean>(false);
  const [IsInvalid, setIsInvalid] = useState<boolean>(false);

  async function FetchLogin(e: FormEvent<HTMLFormElement>) {
    e.preventDefault();

    if (loginInformations.Email !== "" && loginInformations.Password !== "") {
      setIsInvalid(false);
      setIsLoading(true);

      const retorno: retornoLoginComToken = await fetchLoginInformations(
        loginInformations
      );

      toast?.current?.show({
        severity: retorno.data ? "info" : "error",
        summary: "Info",
        detail: retorno.message,
        life: 3500,
      });

      if (retorno.data) {
        sessionStorage.setItem("Token", retorno.data.token);
        window.location.href = PROFILE;
      } else {
        setLoginInformations({ Email: "", Password: "" });
        setIsInvalid(true);
      }

      setIsLoading(false);
    }
  }

  return {
    toast,
    loginInformations,
    setLoginInformations,
    Isloading,
    setIsLoading,
    IsInvalid,
    setIsInvalid,
    FetchLogin,
  };
}
