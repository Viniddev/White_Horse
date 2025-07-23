import { IValidFields } from "@/@types/IValidFields";
import { UserInformations } from "@/@types/req";
import { VALID_FIELDS_EMPTY } from "@/utils/constants/consts";
import { validarDadosUsuario } from "@/validators/formValidators";
import React, { useEffect } from "react";

export default function UseFormPadrao(DefaultUserInformations: UserInformations) {
  const isFirstRender = React.useRef(true);
  const [userInformations, setUserInformations] = React.useState<UserInformations>(DefaultUserInformations);
  const [IsInvalid, setIsInvalid] = React.useState<IValidFields>(VALID_FIELDS_EMPTY);

  useEffect(() => {
    if (isFirstRender.current) {
      isFirstRender.current = false;
      return;
    }

    setUserInformations(DefaultUserInformations);
    setIsInvalid(validarDadosUsuario(DefaultUserInformations));
  }, [DefaultUserInformations]);

  return {
    isFirstRender,
    userInformations,
    IsInvalid,
  };
}