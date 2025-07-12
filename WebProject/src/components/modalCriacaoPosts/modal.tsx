import React, { useState } from "react";
import { Button } from "primereact/button";
import { Dialog } from "primereact/dialog";
import InputTypeText from "../inputs/inputTypeText";

import "./modalStyles.scss";
import { IModalProps } from "@/@types/IModalProps";
import InputTypeTextArea from "../inputs/inputTextArea";
import { IPostRequest } from "@/@types/IPostRequest";
import { UserInformations } from "@/@types/req";
import { fetchPostRequest } from "@/routes/FetchPostRequest";
import { CREATE_POST } from "@/utils/backEndUrls/urls";
import { IResponseGeral } from "@/@types/IResponseGeral";

export default function ModalCriacaoPosts({ visible, setVisible }: IModalProps) {
  const [topic, setTopic] = useState<string>("");
  const [content, setContent] = useState<string>("");
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [IsInvalid, setIsInvalid] = useState<boolean>(false);

  async function CriarPost(){
    setIsLoading(true);
    try{
      if (topic !== "" && content !== '') {
        let creator: UserInformations = JSON.parse(
          sessionStorage.getItem("UserInfo") ?? ""
        );

        const postReq: IPostRequest = {
          topic: topic,
          content: content,
          creatorId: creator.id,
        };

        var response: IResponseGeral = await fetchPostRequest(
          postReq,
          CREATE_POST
        );

        if (response.data !== null) {
          setVisible(false);
          setTopic("");
          setContent("");
        } else {
          setIsInvalid(true);
        }
      } else {
        setIsInvalid(true);
      }

      window.location.reload()
    }catch{
      setIsInvalid(true);
    }

    setIsLoading(false);
  }

  const footerContent = (
    <div>
      <Button
        label="Publicar"
        icon="pi pi-check"
        onClick={() => CriarPost()}
        autoFocus
        loading={isLoading}
      />
    </div>
  );

  return (
    <div className="card flex justify-content-center">
      <Dialog
        modal
        draggable={false}
        visible={visible}
        footer={footerContent}
        style={{ width: "50rem" }}
        header="Quais as novidades, chefia?"
        onHide={() => {
          if (!visible) return;
          setVisible(false);
        }}
      >
        <div className="inputTextArea">
          <InputTypeText
            state={topic}
            setState={(newValue) => setTopic(newValue)}
            label={"Tópico"}
            required={true}
            invalid={IsInvalid}
          />

          <InputTypeTextArea
            state={content}
            setState={(newValue) => setContent(newValue)}
            label={"Descrição"}
            required={true}
            invalid={IsInvalid}
          />
        </div>
      </Dialog>
    </div>
  );
}
