import { UserInformations } from "@/@types/req";
import { fetchPostRequest } from "@/routes/FetchPostRequest";
import { REGISTER } from "@/utils/backEndUrls/urls";
import { EMPTY_USER } from "@/utils/constants/consts";
import { LOGIN } from "@/utils/frontEndUrls/urls";
import { Toast } from "primereact/toast";
import React, { useRef, FormEvent } from "react";
import UseFormPadrao from "./useFormPadrao";
import { validarDadosUsuario } from "@/validators/formValidators";

export default function UseCadastro(){
    const toast = useRef<Toast>(null);
    const [userData, setUserData] = React.useState<UserInformations>(EMPTY_USER);
    const { userInformations } = UseFormPadrao(userData);

    async function RegisterInformations(e: FormEvent<HTMLFormElement>) {
      e.preventDefault();

      var validFields = validarDadosUsuario(userData);

      if(Object.keys(validFields).length > 0){
          toast?.current?.show({
            severity: "error",
            summary: "Info",
            detail: "Não é possível cadastrar o usuário com informações inconsistentes",
            life: 3500,
          });
          return;
      }else {
        let userInfo: any = await fetchPostRequest(userData, REGISTER);

        if (userInfo.data === null) {
          toast?.current?.show({
            severity: "error",
            summary: "Info",
            detail: userInfo.message,
            life: 3500,
          });
          return;
        }

        window.location.href = LOGIN;
        return userInfo.data;
      }
    }

    return {
      userData,
      setUserData,
      userInformations,
      RegisterInformations,
      toast,
    };
}