import swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";

const Swal = withReactContent(swal);
export default Swal;

const avisoTimer = Swal.mixin({
  timer: 3 * 1000,
  timerProgressBar: true,
  showConfirmButton: false,
  didOpen: (alert) => {
    alert.addEventListener("mouseenter", Swal.stopTimer);
    alert.addEventListener("mouseleave", Swal.resumeTimer);
  },
});

export const avisoPadrao = avisoTimer.mixin({
  icon: "success",
});

export const avisoPadraoToast = avisoTimer.mixin({
  icon: "success",
  position: "top-end",
  toast: true,
});

export const avisoPergunta = Swal.mixin({
  icon: "question",
  showConfirmButton: true,
  showCancelButton: true,
  confirmButtonText: "Sim, continuar.",
  cancelButtonText: "Não, cancelar!",
  cancelButtonColor: "#d33",
  customClass: {
    cancelButton: "ms-1 btn btn-danger",
  },
});
