using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Combin : MonoBehaviour
{
	private MeshFilter[] meshFiltersToSkip = new MeshFilter[0];
	private MeshFilter[] GetMeshFiltersToCombine()
	{
		// 모든 하위 오브젝트의 MeshFilter를 저장
		MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>(false);

		// Delete first MeshFilter belongs to this GameObject in meshFiltersToSkip array:
		meshFiltersToSkip = meshFiltersToSkip.Where((meshFilter) => meshFilter != meshFilters[0]).ToArray();

		// 배열에서 null 삭제
		meshFiltersToSkip = meshFiltersToSkip.Where((meshFilter) => meshFilter != null).ToArray();

		for (int i = 0; i < meshFiltersToSkip.Length; i++)
		{
			meshFilters = meshFilters.Where((meshFilter) => meshFilter != meshFiltersToSkip[i]).ToArray();
		}

		return meshFilters;
	}
	public void CombineMultMaterial()
    {
		#region MeshFilter, MeshRenderers, Material Save:
		MeshFilter[] meshFilters = GetMeshFiltersToCombine();
		MeshRenderer[] meshRenderers = new MeshRenderer[meshFilters.Length];
		meshRenderers[0] = GetComponent<MeshRenderer>(); // Our (parent) MeshRenderer.

		List<Material> uniqueMaterialsList = new List<Material>();
		for (int i = 0; i < meshFilters.Length - 1; i++)
		{
			meshRenderers[i + 1] = meshFilters[i + 1].GetComponent<MeshRenderer>();
			if (meshRenderers[i + 1] != null)
			{
				Material[] materials = meshRenderers[i + 1].sharedMaterials; // Get all Materials from child Mesh.
				for (int j = 0; j < materials.Length; j++)
				{
					if (!uniqueMaterialsList.Contains(materials[j])) // If Material doesn't exists in the list then add it.
					{
						uniqueMaterialsList.Add(materials[j]);
					}
				}
			}
		}
		#endregion MeshFilter, MeshRenderers, Material Save.

	}
}

