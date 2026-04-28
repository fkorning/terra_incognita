# Registry Design for Multi-Registry Support

## Goal

Enable a generic registry architecture that starts with Terraform and can later support other registry types such as Kubernetes and Docker.

## High-Level Approach

- Keep Terraform first as the initial implementation target.
- Use a generic `plugins/` folder for provider/plugin artifacts.
- Preserve Terraform Registry Protocol compatibility by exposing `/providers/` paths through a symlink.
- Keep modules under `modules/` alongside `plugins/` within each registry root.
- Allow future registries to follow the same pattern with their own root under `registry/`.

## Core Structure

The current canonical layout is:

- `registry/`
  - `terraform@ -> registry.terraform.io/`
  - `registry.terraform.io/`
    - `plugins/`
    - `providers@ -> plugins/`
    - `modules/`
  - `kubernetes@ -> registry.k8s.io/` (future)
  - `registry.k8s.io/`
    - `plugins/`
    - `charts/`
  - `docker@ -> registry.hub.docker.com/` (future)
  - `registry.hub.docker.com/`
    - `manifests/`
    - `images/`

## Design Principles

- Use generic folder names where possible to make the registry model reusable.
- Keep protocol-compatible aliases in place so existing Terraform expectations continue to work.
- Separate implementation details from the abstract registry concept.
- Design for incremental expansion to additional registry types.
</content>
<parameter name="filePath">c:\work\workspace\dsp\cloud\iac\terra_incognita\proposed_structure_update.md