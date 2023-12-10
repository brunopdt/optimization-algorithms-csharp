import {
  Box,
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

export const DialogGenerateRoutes = () => {
  const [open, setOpen] = useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };
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
        <DialogContent>
          <TextField
            autoFocus
            margin="dense"
            id="name"
            label="Tamanho rotas"
            type="number"
            fullWidth
            variant="outlined"
          />
          <TextField
            autoFocus
            margin="dense"
            id="name"
            label="Quantidade rotas"
            type="number"
            fullWidth
            variant="outlined"
          />
          <TextField
            autoFocus
            margin="dense"
            id="name"
            label="Disperção"
            type="number"
            fullWidth
            variant="outlined"
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
            onClick={handleClose}
          >
            Gerar Rotas
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};
