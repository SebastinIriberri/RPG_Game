using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventarioUI : Singleton<InventarioUI> {
    [Header("Panel Inventario Descripcion")]
    [SerializeField] private GameObject panelInventarioDescripcion;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemNombre;
    [SerializeField] private TextMeshProUGUI itemDescripcion;
    [SerializeField] private InventarioSlot slotPrefab;
    [SerializeField] private Transform contenedor;

    public int  IndexSlotInicialPorMover { get;private set; }
    public InventarioSlot SlotSeleccionado { get; private set; }
    List<InventarioSlot> slotsDisponibles = new List<InventarioSlot>();

    private void Start() {
        InicializarInventario();
        IndexSlotInicialPorMover = -1; 
    }

    private void Update() {
        ActulizarSlotSelecionado();
        if (Input.GetKeyDown(KeyCode.M)) {
            if (SlotSeleccionado != null) { 
                IndexSlotInicialPorMover = SlotSeleccionado.Index;
            }
        }
    }
    private void InicializarInventario() {
        for (int i = 0; i < Inventario.Instance.NumeroDeSloats; i++) {
           InventarioSlot nuevoSlot =  Instantiate(slotPrefab,contenedor);
            nuevoSlot.Index = i;
           slotsDisponibles.Add(nuevoSlot);
        }
    }

    private void ActulizarSlotSelecionado() { 
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        if (goSelecionado == null) {
            return;
        }
        InventarioSlot slot = goSelecionado.GetComponent<InventarioSlot>();
        if (slot != null) { 
            SlotSeleccionado = slot;
        }
    }

    public void DibujarIteamInventario(InventarioItem iteamPorAñadir,int cantidad ,int iteamIndex) {
        InventarioSlot slot = slotsDisponibles[iteamIndex];
        if (iteamPorAñadir != null) {
            slot.ActivarSloatUI(true);
            slot.ActulizarSlot(iteamPorAñadir, cantidad);
        }
        else { 
            slot.ActivarSloatUI(false); 
        }
    }
    private void ActulizarInventarioDescripcion(int index ) {
        if (Inventario.Instance.ItemsInventario[index] != null) {
            itemIcon.sprite = Inventario.Instance.ItemsInventario[index].Icono;
            itemNombre.text = Inventario.Instance.ItemsInventario[index].Nombre;
            itemDescripcion.text = Inventario.Instance.ItemsInventario[index].Descripcion;
            panelInventarioDescripcion.SetActive(true);
        }
        else { 
            panelInventarioDescripcion.SetActive(false); 
        }
    }
    public void UsarItem() {
        if (SlotSeleccionado != null) {
            SlotSeleccionado.SlotUsarItem();
            SlotSeleccionado.SelecionarSlot();
        }
    }

    #region Evento
    private void SlotInteraccionRespuesta(TipoDeInteraccion tipo , int index) {
        if (tipo == TipoDeInteraccion.Click) { 
            ActulizarInventarioDescripcion (index);
        }
    }

    private void OnEnable() {
        InventarioSlot.EventoSlotInteraccion += SlotInteraccionRespuesta; 
    }
    private void OnDisable() {
        InventarioSlot.EventoSlotInteraccion -= SlotInteraccionRespuesta;
    }

    #endregion
}
