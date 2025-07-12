import { UserInformations } from "@/@types/req";
import { validarDadosUsuario } from "@/validators/formValidators";
import React, { useEffect } from "react";

export default function UseFormPadrao(DefaultUserInformations: UserInformations) {
  const isFirstRender = React.useRef(true);
  const [userInformations, setUserInformations] = React.useState<UserInformations>(DefaultUserInformations);
  const [IsInvalid, setIsInvalid] = React.useState<boolean>(false);

  useEffect(() => {
    setUserInformations(DefaultUserInformations);
  }, [DefaultUserInformations]);

  useEffect(() => {
    var response = validarDadosUsuario(userInformations);

    if(Object.keys(response).length > 0)
      setIsInvalid(true)

  }, [userInformations]);

  useEffect(() => {
    if (isFirstRender.current) {
      isFirstRender.current = false;
      return;
    }
    setUserInformations((prevState) => ({
      ...prevState,
      ...DefaultUserInformations,
    }));
  }, [DefaultUserInformations]);

  return {
    isFirstRender,
    userInformations,
    setUserInformations,
    IsInvalid,
  };
}