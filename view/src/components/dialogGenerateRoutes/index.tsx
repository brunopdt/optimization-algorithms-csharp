import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  IconButton,
  TextField,
  Typography,
} from "@mui/material";
import { useState } from "react";
import IconifyIcon from "../icon";
import * as yup from "yup";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { queryClient } from "@/services/reactQuery.service";
import api from "@/axios/useApi";
import { useMutation } from "@tanstack/react-query";
import { avisoPadrao, avisoPadraoToast, avisoPergunta } from "../sweetalert2";
const defaultValue = {
  quantRoutes: 10,
  sizeSet: 10,
  dispersion: 1,
};

const schema = yup.object().shape({
  quantRoutes: yup.number().required("Campo obrigatorio."),
  sizeSet: yup.number().required("Campo obrigatorio."),
  dispersion: yup.number().required("Campo obrigatorio."),
});

export const DialogGenerateRoutes = () => {
  const [open, setOpen] = useState(false);
  const {
    control,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm({
    mode: "onBlur",
    values: defaultValue,
    resolver: yupResolver(schema),
  });
  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    reset();
    setOpen(false);
  };

  let mutationSalvarReq = useMutation({
    mutationFn: (data) => {
      return api.post("/generate", data).then(({ data }) => data);
    },
    onSuccess: (data) => {
      queryClient.refetchQueries(["routes"]);
      handleClose();
      avisoPadraoToast.fire({
        title: "Sucesso",
        text: "Rotas geradas com sucesso",
      });
    },
    onError: ({ response }) => {
      handleClose();
      avisoPadrao.fire({
        icon: "error",
        title: "Atenção",
        text: "Erro inesperado!",
      });
    },
  });

  return (
    <>
      <IconButton color="info" onClick={handleClickOpen}>
        <IconifyIcon icon="basil:add-outline" />
      </IconButton>
      <Dialog open={open} onClose={handleClose}>
        <DialogTitle color={"white"} textAlign={"center"}>
          <IconifyIcon icon={"line-md:cog-filled-loop"} fontSize={40} />
          <Typography variant="body1">Gerador de rotas</Typography>
        </DialogTitle>
        <form
          onSubmit={handleSubmit((data: any) => mutationSalvarReq.mutate(data))}
        >
          <DialogContent>
            <Controller
              name="sizeSet"
              key="sizeSet"
              control={control}
              rules={{ required: true }}
              render={({ field }) => (
                <TextField
                  variant="outlined"
                  sx={{ mb: 3 }}
                  fullWidth
                  label="Quantidade de rotas"
                  {...field}
                  error={Boolean(errors.sizeSet)}
                  FormHelperTextProps={{ color: "error.main" }}
                  helperText={errors.sizeSet?.message as string}
                />
              )}
            />
            <Controller
              name="quantRoutes"
              key="quantRoutes"
              control={control}
              rules={{ required: true }}
              render={({ field }) => (
                <TextField
                  variant="outlined"
                  sx={{ mb: 3 }}
                  fullWidth
                  label="Tamanho rotas"
                  {...field}
                  error={Boolean(errors.quantRoutes)}
                  FormHelperTextProps={{ color: "error.main" }}
                  helperText={errors.quantRoutes?.message as string}
                />
              )}
            />
            <Controller
              name="dispersion"
              key="dispersion"
              control={control}
              rules={{ required: true }}
              render={({ field }) => (
                <TextField
                  variant="outlined"
                  sx={{ mb: 3 }}
                  fullWidth
                  label="Disperção"
                  {...field}
                  error={Boolean(errors.dispersion)}
                  FormHelperTextProps={{ color: "error.main" }}
                  helperText={errors.dispersion?.message as string}
                />
              )}
            />
          </DialogContent>
          <DialogActions>
            <Button
              variant="outlined"
              color="error"
              startIcon={<IconifyIcon icon={"mdi:close"} />}
              onClick={handleClose}
            >
              Cancelar
            </Button>
            <Button
              variant="outlined"
              color="info"
              startIcon={<IconifyIcon icon={"mdi:routes"} />}
              type="submit"
            >
              Gerar Rotas
            </Button>
          </DialogActions>
        </form>
      </Dialog>
    </>
  );
};
