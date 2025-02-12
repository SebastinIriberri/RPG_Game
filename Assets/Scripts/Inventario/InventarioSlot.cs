using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TipoDeInteraccion {Click, Usar , Equipar, Remover  }

public class InventarioSlot : MonoBehaviour {
    public static Action<TipoDeInteraccion, int> EventoSlotInteraccion; 
    [SerializeField] private Image itemIcono;
    [SerializeField] private GameObject fondoCantidad;
    [SerializeField] private TextMeshProUGUI cantidadTMP;
    public int Index { get; set; }
    private Button _button;

    private void Awake() {
        _button = GetComponent<Button>();
    }

    public void ActulizarSlot(InventarioItem item, int cantidad){ 
        itemIcono.sprite = item.Icono;
        cantidadTMP.text = cantidad.ToString();
    }

    public void ActivarSloatUI(bool estado) { 
        itemIcono.gameObject.SetActive(estado);
        fondoCantidad.SetActive(estado);
    }
    public void SelecionarSlot() { 
        _button.Select();
    }
    public void ClickSlot() {
        EventoSlotInteraccion?.Invoke(TipoDeInteraccion.Click,Index);

        if (InventarioUI.Instance.IndexSlotInicialPorMover != -1) {
            if (InventarioUI.Instance.IndexSlotInicialPorMover != Index) {
                Inventario.Instance.MoverItem(InventarioUI.Instance.IndexSlotInicialPorMover, Index);
            }
        }
    }

    public void SlotUsarItem() {
        if (Inventario.Instance.ItemsInventario[Index] != null) {
            EventoSlotInteraccion?.Invoke(TipoDeInteraccion.Usar,Index);
        }
    }
}
