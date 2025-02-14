import React from "react";
import InputTypeText from "../inputs/inputTypeText";
import { Button } from "primereact/button";
import { UserInformations } from "@/@types/req";
import InputTypeNumber from "../inputs/inputTypeNumber";
import InputTypeMask from "../inputs/inputTypeMask";
import { BuildDefaultForm } from "@/@types/components";
import InputCep from "../inputs/inputCep";

export default function FormPadrao({ IsRegister, DefaultUserInformations }: BuildDefaultForm) {
  const isFirstRender = React.useRef(true);
  const [userInformations, setUserInformations] = React.useState<UserInformations>(DefaultUserInformations);
  const [IsInvalid, setIsInvalid] = React.useState<boolean>(false);

  React.useEffect(() => {
    setUserInformations(DefaultUserInformations);
  }, [DefaultUserInformations]);

  React.useEffect(() => {
    if (isFirstRender.current) {
      isFirstRender.current = false;
      return;
    }
    setUserInformations((prevState) => ({
      ...prevState,
      ...DefaultUserInformations,
    }));
  }, [DefaultUserInformations]);

  return (
    <div>
      <div className="formgrid grid">
        {IsRegister ? (
          <>
            <div className="field col-12 lg:col-6">
              <InputTypeText
                state={userInformations.name}
                setState={(newValue) =>
                  setUserInformations((prevState) => ({
                    ...prevState,
                    name: newValue,
                  }))
                }
                label={"Nome"}
                required={IsRegister ? true : false}
                invalid={IsInvalid}
              />
            </div>
            <div className="field col-12 lg:col-6">
              <InputTypeMask
                state={userInformations.cpf}
                setState={(newValue) =>
                  setUserInformations((prevState) => ({
                    ...prevState,
                    cpf: newValue,
                  }))
                }
                mask="999.999.999-99"
                label={"Cpf"}
                required={IsRegister ? true : false}
                invalid={IsInvalid}
              />
            </div>
            <div className="field col-12 lg:col-6">
              <InputTypeMask
                state={userInformations.rg}
                setState={(newValue) =>
                  setUserInformations((prevState) => ({
                    ...prevState,
                    rg: newValue,
                  }))
                }
                mask="99.999.999"
                label={"Rg"}
                required={IsRegister ? true : false}
                invalid={IsInvalid}
              />
            </div>
            <div className="field col-12 lg:col-6">
              <InputTypeText
                state={userInformations.role}
                setState={(newValue) =>
                  setUserInformations((prevState) => ({
                    ...prevState,
                    role: newValue,
                  }))
                }
                label={"Cargo"}
                required={IsRegister ? true : false}
                invalid={IsInvalid}
              />
            </div>
          </>
        ) : (
          ""
        )}
        <div className="field col-12 lg:col-6">
          <InputTypeText
            state={userInformations.email}
            setState={(newValue) =>
              setUserInformations((prevState) => ({
                ...prevState,
                email: newValue,
              }))
            }
            label={"E-mail"}
            required={true}
            invalid={IsInvalid}
          />
        </div>
        <div className="field col-12 lg:col-6">
          <InputTypeMask
            state={userInformations.phoneNumber}
            setState={(newValue) =>
              setUserInformations((prevState) => ({
                ...prevState,
                phoneNumber: newValue,
              }))
            }
            mask="(99) 99999-9999"
            label={"Telefone"}
            required={true}
            invalid={IsInvalid}
          />
        </div>
        <div className="field col-12 lg:col-6">
          <InputCep
            state={userInformations}
            setState={setUserInformations}
            mask="99999-999"
            label={"Cep"}
            required={true}
            invalid={IsInvalid}
          />
        </div>
        <div className="field col-12 lg:col-6">
          <InputTypeText
            state={userInformations.address.street}
            setState={(newValue: string) =>
              setUserInformations((prevState) => ({
                ...prevState,
                address: {
                  ...prevState.address,
                  street: newValue,
                },
              }))
            }
            label={"Rua"}
            required={true}
            invalid={IsInvalid}
          />
        </div>

        <div className="field col-12 lg:col-6">
          <InputTypeText
            state={userInformations.address.neighborhood}
            setState={(newValue: string) =>
              setUserInformations((prevState) => ({
                ...prevState,
                endereco: {
                  ...prevState.address,
                  neighborhood: newValue,
                },
              }))
            }
            label={"Bairro"}
            required={true}
            invalid={IsInvalid}
          />
        </div>
        <div className="field col-12 lg:col-6">
          <InputTypeNumber
            state={userInformations.address.number}
            setState={(newValue: number) =>
              setUserInformations((prevState) => ({
                ...prevState,
                endereco: {
                  ...prevState.address,
                  number: newValue,
                },
              }))
            }
            label={"Número"}
            required={true}
            invalid={IsInvalid}
          />
        </div>

        <div className="field col-12 lg:col-6">
          <InputTypeText
            state={userInformations.address.city}
            setState={(newValue: string) =>
              setUserInformations((prevState) => ({
                ...prevState,
                endereco: {
                  ...prevState.address,
                  city: newValue,
                },
              }))
            }
            label={"Cidade"}
            required={true}
            invalid={IsInvalid}
          />
        </div>

        <div className="field col-12">
          <div className="sessaoBotaoSalvar">
            <Button label="Atualizar" severity="danger" />
          </div>
        </div>
      </div>
    </div>
  );
}
